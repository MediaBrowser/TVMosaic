using System;
using System.Net;

using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;
using TSoft.TVServer.Helpers;

namespace TSoft.TVServer.Entities
{
    /// <summary> A program. </summary>
	[XmlRoot("program")]
    public class Program
    {
        #region [Public Properties]
        /// <summary> Gets or sets the identifier of the program. </summary>
        /// <value> The identifier of the program. </value>
        [XmlElement(ElementName = "program_id")]
        public string ProgramID { get; set; }

        /// <summary> Gets or sets the name. </summary>
        /// <value> The name. </value>
		[XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary> Gets or sets the start time. </summary>
        /// <value> The start time. </value>
		[XmlElement(ElementName = "start_time")]
        public long StartTime { get; set; }

        /// <summary> Gets or sets the duration. </summary>
        /// <value> The duration. </value>
		[XmlElement(ElementName = "duration")]
        public long Duration { get; set; }

        /// <summary> Gets or sets information describing the short. </summary>
        /// <value> Information describing the short. </value>
		[XmlElement(ElementName = "short_desc"), DefaultValue("")]
        public string ShortDesc { get; set; }

        /// <summary> Gets or sets the subname. </summary>
        /// <value> The subname. </value>
		[XmlElement(ElementName = "subname"), DefaultValue("")]
        public string Subname { get; set; }

        /// <summary> Gets or sets the language. </summary>
        /// <value> The language. </value>
		[XmlElement(ElementName = "language"), DefaultValue("")]
        public string Language { get; set; }

        /// <summary> Gets or sets the actors. </summary>
        /// <value> The actors. </value>
		[XmlElement(ElementName = "actors"), DefaultValue("")]
        public string Actors { get; set; }

        /// <summary> Gets or sets the directors. </summary>
        /// <value> The directors. </value>
		[XmlElement(ElementName = "directors"), DefaultValue("")]
        public string Directors { get; set; }

        /// <summary> Gets or sets the writers. </summary>
        /// <value> The writers. </value>
		[XmlElement(ElementName = "writers"), DefaultValue("")]
        public string Writers { get; set; }

        /// <summary> Gets or sets the producers. </summary>
        /// <value> The producers. </value>
		[XmlElement(ElementName = "producers"), DefaultValue("")]
        public string Producers { get; set; }

        /// <summary> Gets or sets the guests. </summary>
        /// <value> The guests. </value>
		[XmlElement(ElementName = "guests"), DefaultValue("")]
        public string Guests { get; set; }

        /// <summary> Gets or sets the categories. </summary>
        /// <value> The categories. </value>
		[XmlElement(ElementName = "categories"), DefaultValue("")]
        public string Categories { get; set; }

        /// <summary> Gets or sets the image. </summary>
        /// <value> The image. </value>
		[XmlElement(ElementName = "image"), DefaultValue("")]
        public string Image { get; set; }

        /// <summary> Gets or sets the year. </summary>
        /// <value> The year. </value>
		[XmlElement(ElementName = "year"), DefaultValue(0)]
        public long Year { get; set; }

        /// <summary> Gets or sets the episode number. </summary>
        /// <value> The episode number. </value>
		[XmlElement(ElementName = "episode_num"), DefaultValue(0)]
        public long EpisodeNum { get; set; }

        /// <summary> Gets or sets the season number. </summary>
        /// <value> The season number. </value>
		[XmlElement(ElementName = "season_num"), DefaultValue(0)]
        public long SeasonNum { get; set; }

        /// <summary> Gets or sets the stars number. </summary>
        /// <value> The stars number. </value>
		[XmlElement(ElementName = "stars_num"), DefaultValue(0)]
        public long StarsNum { get; set; }

        /// <summary> Gets or sets the stars maximum number. </summary>
        /// <value> The stars maximum number. </value>
		[XmlElement(ElementName = "starsmax_num"), DefaultValue(0)]
        public long StarsMaxNum { get; set; }

        /// <summary> Gets or sets a value indicating whether the hdtv. </summary>
        /// <value> true if hdtv, false if not. </value>
		[XmlElement(ElementName = "hdtv"), DefaultValue(false)]
        public bool Hdtv { get; set; }

        /// <summary> Gets or sets a value indicating whether the premiere. </summary>
        /// <value> true if premiere, false if not. </value>
		[XmlElement(ElementName = "premiere"), DefaultValue(false)]
        public bool Premiere { get; set; }

        /// <summary> Gets or sets a value indicating whether the repeat. </summary>
        /// <value> true if repeat, false if not. </value>
		[XmlElement(ElementName = "repeat"), DefaultValue(false)]
        public bool Repeat { get; set; }

        /// <summary> Gets or sets a value indicating whether the category action. </summary>
        /// <value> true if category action, false if not. </value>
		[XmlElement(ElementName = "cat_action"), DefaultValue(false)]
        public bool CatAction { get; set; }

        /// <summary> Gets or sets a value indicating whether the category comedy. </summary>
        /// <value> true if category comedy, false if not. </value>
		[XmlElement(ElementName = "cat_comedy"), DefaultValue(false)]
        public bool CatComedy { get; set; }

        /// <summary> Gets or sets a value indicating whether the category documentary. </summary>
        /// <value> true if category documentary, false if not. </value>
		[XmlElement(ElementName = "cat_documentary"), DefaultValue(false)]
        public bool CatDocumentary { get; set; }

        /// <summary> Gets or sets a value indicating whether the category drama. </summary>
        /// <value> true if category drama, false if not. </value>
		[XmlElement(ElementName = "cat_drama"), DefaultValue(false)]
        public bool CatDrama { get; set; }

        /// <summary> Gets or sets a value indicating whether the category educational. </summary>
        /// <value> true if category educational, false if not. </value>
		[XmlElement(ElementName = "cat_educational"), DefaultValue(false)]
        public bool CatEducational { get; set; }

        /// <summary> Gets or sets a value indicating whether the category horror. </summary>
        /// <value> true if category horror, false if not. </value>
		[XmlElement(ElementName = "cat_horror"), DefaultValue(false)]
        public bool CatHorror { get; set; }

        /// <summary> Gets or sets a value indicating whether the category kids. </summary>
        /// <value> true if category kids, false if not. </value>
		[XmlElement(ElementName = "cat_kids"), DefaultValue(false)]
        public bool CatKids { get; set; }

        /// <summary> Gets or sets a value indicating whether the category movie. </summary>
        /// <value> true if category movie, false if not. </value>
		[XmlElement(ElementName = "cat_movie"), DefaultValue(false)]
        public bool CatMovie { get; set; }

        /// <summary> Gets or sets a value indicating whether the category music. </summary>
        /// <value> true if category music, false if not. </value>
		[XmlElement(ElementName = "cat_music"), DefaultValue(false)]
        public bool CatMusic { get; set; }

        /// <summary> Gets or sets a value indicating whether the category news. </summary>
        /// <value> true if category news, false if not. </value>
		[XmlElement(ElementName = "cat_news"), DefaultValue(false)]
        public bool CatNews { get; set; }

        /// <summary> Gets or sets a value indicating whether the category reality. </summary>
        /// <value> true if category reality, false if not. </value>
		[XmlElement(ElementName = "cat_reality"), DefaultValue(false)]
        public bool CatReality { get; set; }

        /// <summary> Gets or sets a value indicating whether the category romance. </summary>
        /// <value> true if category romance, false if not. </value>
		[XmlElement(ElementName = "cat_romance"), DefaultValue(false)]
        public bool CatRomance { get; set; }

        /// <summary> Gets or sets a value indicating whether the category scifi. </summary>
        /// <value> true if category scifi, false if not. </value>
		[XmlElement(ElementName = "cat_scifi"), DefaultValue(false)]
        public bool CatScifi { get; set; }

        /// <summary> Gets or sets a value indicating whether the category serial. </summary>
        /// <value> true if category serial, false if not. </value>
		[XmlElement(ElementName = "cat_serial"), DefaultValue(false)]
        public bool CatSerial { get; set; }

        /// <summary> Gets or sets a value indicating whether the category SOAP. </summary>
        /// <value> true if category soap, false if not. </value>
		[XmlElement(ElementName = "cat_soap"), DefaultValue(false)]
        public bool CatSoap { get; set; }

        /// <summary> Gets or sets a value indicating whether the category special. </summary>
        /// <value> true if category special, false if not. </value>
		[XmlElement(ElementName = "cat_special"), DefaultValue(false)]
        public bool CatSpecial { get; set; }

        /// <summary> Gets or sets a value indicating whether the category sports. </summary>
        /// <value> true if category sports, false if not. </value>
		[XmlElement(ElementName = "cat_sports"), DefaultValue(false)]
        public bool CatSports { get; set; }

        /// <summary> Gets or sets a value indicating whether the category thriller. </summary>
        /// <value> true if category thriller, false if not. </value>
		[XmlElement(ElementName = "cat_thriller"), DefaultValue(false)]
        public bool CatThriller { get; set; }

        /// <summary> Gets or sets a value indicating whether the category adult. </summary>
        /// <value> true if category adult, false if not. </value>
		[XmlElement(ElementName = "cat_adult"), DefaultValue(false)]
        public bool CatAdult { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this TSoft.TVServer.Entities.Program is
        /// record. </summary>
        /// <value> true if this TSoft.TVServer.Entities.Program is record, false if not. </value>
		[XmlElement(ElementName = "is_record"), DefaultValue(false)]
        public bool IsRecord { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this TSoft.TVServer.Entities.Program is
        /// series. </summary>
        /// <value> true if this TSoft.TVServer.Entities.Program is series, false if not. </value>
		[XmlElement(ElementName = "is_series"), DefaultValue(false)]
        public bool IsSeries { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this TSoft.TVServer.Entities.Program is repeat
        /// record. </summary>
        /// <value>
        /// true if this TSoft.TVServer.Entities.Program is repeat record, false if not. </value>
		[XmlElement(ElementName = "is_repeat_record"), DefaultValue(false)]
        public bool IsRepeatRecord { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this TSoft.TVServer.Entities.Program is record
        /// conflict. </summary>
        /// <value>
        /// true if this TSoft.TVServer.Entities.Program is record conflict, false if not. </value>
        [XmlElement(ElementName = "is_record_conflict"), DefaultValue(false)]
        public bool IsRecordConflict { get; set; }

        #endregion
        
        #region [Public Methods]
        /// <summary> Gets star date offset. </summary>
        /// <returns> The star date offset. </returns>
        public DateTimeOffset GetStarDateOffset()
        {
            return DateTimeExtensions.DateTimeFromUnixTimestampOffsetSeconds(this.StartTime);
        }

        /// <summary> Gets end date offset. </summary>
        /// <returns> The end date offset. </returns>
        public DateTimeOffset GetEndDateOffset()
        {
            return DateTimeExtensions.DateTimeFromUnixTimestampOffsetSeconds(this.StartTime).AddSeconds(this.Duration);
        }
        #endregion
    }
}
