// <copyright file="LiveTvServiceBase.cs" >
// Copyright (c) 2017 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares André</author>
// <date>01.09.2017</date>
// <summary>Implements the live TV service class</summary>
using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediaBrowser.Model.Dto;
using MediaBrowser.Controller.LiveTv;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Model.LiveTv;
using MediaBrowser.Model.Configuration;
using MediaBrowser.Model.MediaInfo;
using TSoft.TVServer;
using MediaBrowser.Model.Serialization;
using Emby.Plugins.DVBLogic.Helpers;
using TSoft.TVServer.Entities;
using TSoft.TVServer.Helpers;
using MediaBrowser.Model.Entities;
using Emby.Plugins.DVBLogic.Proxies;
using MediaBrowser.Common.Net;

namespace Emby.Plugins.TVMosaic
{
    /// <summary> A live TV service base. </summary>
    /// <seealso cref="T:MediaBrowser.Controller.LiveTv.ILiveTvService"/>
    public class LiveTvService : BaseTunerHost, ITunerHost
    {
        private readonly TVServerClient _client;

        public LiveTvService(IServerApplicationHost appHost, IHttpClient httpClient, IXmlSerializer xmlSerializer)
            : base(appHost)
        {
            var pluginHttpClient = new PluginHttpClient(Logger, httpClient, xmlSerializer);

            _client = new TVServerClient(TSoft.TVServer.Constants.EnumTVServerClientType.TVMosaic, pluginHttpClient, Logger);
        }

        public override string Type => "tvmosaic";
        public override string Name => Plugin.StaticName;

        public override string SetupUrl
        {
            get { return Plugin.GetPluginPageUrl(Type); }
        }

        public override bool SupportsGuideData(TunerHostInfo tuner)
        {
            return true;
        }

        public override TunerHostInfo GetDefaultConfiguration()
        {
            var tuner = base.GetDefaultConfiguration();

            tuner.Url = "http://localhost:9270";

            SetCustomOptions(tuner, new TvMosaicProviderOptions());

            return tuner;
        }

        protected override async Task<List<ChannelInfo>> GetChannelsInternal(TunerHostInfo tuner, CancellationToken cancellationToken)
        {
            var channels = new List<ChannelInfo>();
            var config = GetProviderOptions<TvMosaicProviderOptions>(tuner);

            Logger.Info("Get Channels");

            var result = await _client.GetChannelsAsync(tuner, config, cancellationToken).ConfigureAwait(false);

            Logger.Info("Channels found on server: {0}", result.Items.Count);

            result = _client.UpdateChannels(result);
            var selectedChannels = result.Items;

            foreach (var channel in selectedChannels)
            {
                channels.Add(new ChannelInfo
                {
                    Id = channel.ChannelDVBLinkID,
                    Name = channel.Name,
                    Number = channel.Number.ToString(),
                    ImageUrl = channel.HasChannelLogo && channel.ServerLogo ? channel.ChannelLogo : null,
                    ChannelType = ChannelHelper.GetChannelType(channel.Type),
                    IsHD = channel.IsHD
                });
            }

            Logger.Info("Channels saved to cache");

            foreach (var channel in channels)
            {
                channel.TunerHostId = tuner.Id;
                channel.Id = CreateEmbyChannelId(tuner, channel.Id);
            }

            return channels.Cast<ChannelInfo>().ToList();
        }

        protected override Task<List<MediaSourceInfo>> GetChannelStreamMediaSources(TunerHostInfo tuner, BaseItem dbChannnel, ChannelInfo providerChannel, CancellationToken cancellationToken)
        {
            var config = GetProviderOptions<TvMosaicProviderOptions>(tuner);

            var channelId = GetTunerChannelIdFromEmbyChannelId(tuner, providerChannel.Id);

            var mediaSource = new MediaSourceInfo
            {
                Id = Type + "_" + channelId,
                Path = _client.GetDirectChannelStream(tuner, config, _client.ClientId, channelId),
                Protocol = MediaProtocol.Http,
                MediaStreams = new List<MediaStream>
                            {
                                new MediaStream
                                {
                                    Type = MediaStreamType.Video,
                                    // Set the index to -1 because we don't know the exact index of the video stream within the container
                                    Index = -1,
                                    // Set to true if unknown to enable deinterlacing
                                    IsInterlaced = true
                                },
                                new MediaStream
                                {
                                    Type = MediaStreamType.Audio,
                                    // Set the index to -1 because we don't know the exact index of the audio stream within the container
                                    Index = -1
                                }
                            },

                RequiresOpening = true,
                RequiresClosing = true,

                SupportsDirectPlay = false,
                SupportsDirectStream = true,
                SupportsTranscoding = true,
                IsInfiniteStream = true
            };

            return Task.FromResult(new List<MediaSourceInfo> { mediaSource });
        }

        protected override async Task<List<ProgramInfo>> GetProgramsInternal(TunerHostInfo tuner, string tunerChannelId, DateTimeOffset startDateUtc, DateTimeOffset endDateUtc, CancellationToken cancellationToken)
        {
            var config = GetProviderOptions<TvMosaicProviderOptions>(tuner);

            Logger.Info(string.Format("Get Programs, retrieve all programs for ChannelId: {0}", tunerChannelId));

            var programList = new List<ProgramInfo>();
            var request = new EpgRequest(tunerChannelId, startDateUtc.GetCurrentUnixTimestampOffsetSeconds(), endDateUtc.GetCurrentUnixTimestampOffsetSeconds());

            var result = await this._client.GetEpgAsync(request, tuner, config, cancellationToken).ConfigureAwait(false);

            var programs = result.Items.FirstOrDefault()?.Programs.Items ?? new List<Program>();

            Logger.Info("Programs found for channel : {0} - {1}", tunerChannelId, programs);

            var list = new List<ProgramInfo>();

            foreach (var item in programs)
            {
                int? year = (int)item.Year;
                if (year <= 0)
                    year = null;

                int? seasonNumber = (int)item.SeasonNum;
                if (seasonNumber <= 0)
                    seasonNumber = null;

                int? episodeNum = (int)item.EpisodeNum;
                if (episodeNum <= 0)
                    episodeNum = null;
                var program = new ProgramInfo
                {
                    Id = item.ProgramID,
                    ChannelId = tunerChannelId,
                    //Id = item.ID,
                    Overview = item.ShortDesc,
                    StartDate = item.GetStarDateOffset(),
                    EndDate = item.GetEndDateOffset(),
                    ImageUrl = item.Image,
                    //ThumbImageUrl = item.Image,
                    IsRepeat = item.Repeat,
                    IsPremiere = item.Premiere,
                    IsHD = item.Hdtv,
                    IsMovie = item.CatMovie,
                    IsNews = item.CatNews,
                    IsSeries = item.IsSeries,
                    IsSports = item.CatSports,
                    IsKids = item.CatKids,
                    IsEducational = item.CatEducational,
                    ProductionYear = year,
                    SeasonNumber = seasonNumber,
                    EpisodeNumber = episodeNum
                };

                if (!string.IsNullOrEmpty(item.Name))
                {
                    program.Name = item.Name;
                }

                if (!string.IsNullOrEmpty(item.Subname))
                {
                    program.EpisodeTitle = item.Subname;
                };

                if (!string.IsNullOrEmpty(item.Categories))
                {
                    program.Genres = new List<string>(item.Categories.ToString().Split('/'));
                }
                programList.Add(program);
            }

            foreach (var item in list)
            {
                item.ChannelId = tunerChannelId;
                item.Id = GetProgramEntryId(item.ShowId, item.StartDate, item.ChannelId);
            }

            return list;
        }
    }
}
