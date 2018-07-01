/**
 * UNITY BULLETIN
 * by Sam Wilcox (sam@unitybulletin.com)
 * 
 * Email:          sam@unitybulletin.com
 * World Wide Web: http://www.unitybulletin.com
 * Ditributed By:  http://www.unitybulletin.com
 * 
 * (C)Copyright Unity Bulletin.
 * (R)All Rights Reserved.
 * 
 * USER-END LICENSE AGREEMENT:
 * 
 * This file is part of Foobar.
 * 
 * Unity Bulletin is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * Unity Bulletin is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Unity Bulletin.  If not, see <https://www.gnu.org/licenses/>.
 **/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using UnityBulletin.Library;

namespace UnityBulletin
{
    #region Enumerations

    /// <summary>
    /// Enumeration of different SQL query statements.
    /// </summary>
    public enum SqlStatement
    {

    }

    #endregion Enumerations

    public class Master
    {
        #region Public Members

        /// <summary>
        /// Application configurations data collection.
        /// </summary>
        public Dictionary<string, object> cfg = new Dictionary<string, object>();

        /// <summary>
        /// Incoming data collection.
        /// </summary>
        public Dictionary<string, string> inc = new Dictionary<string, string>();

        /// <summary>
        /// Member data collection.
        /// </summary>
        public Dictionary<string, object> member = new Dictionary<string, object>();

        /// <summary>
        /// User agent data collection.
        /// </summary>
        public Dictionary<string, string> agent = new Dictionary<string, string>();

        /// <summary>
        /// Session data collection.
        /// </summary>
        public Dictionary<string, string> session = new Dictionary<string, string>();

        /// <summary>
        /// Language localization data collection.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> lang = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Timer instance.
        /// </summary>
        public Stopwatch timer;

        /// <summary>
        /// Base application URL.
        /// </summary>
        public string baseUrl;

        /// <summary>
        /// Imageset URL.
        /// </summary>
        public string imagesetUrl;

        /// <summary>
        /// Language path.
        /// </summary>
        public string langPath;

        #endregion Public Members

        #region Class Constructor

        /// <summary>
        /// Default class constructor.
        /// </summary>
        public Master() { }

        #endregion Class Constructor

        #region Public Methods

        /// <summary>
        /// Populates all language localization into the respected data collection.
        /// </summary>
        public void PopulateLocalizationValues()
        {
            string[] langFiles = Directory.GetFiles(this.langPath, "*.Lang.xml", SearchOption.TopDirectoryOnly);

            foreach (string file in langFiles)
            {
                Dictionary<string, string> lang = new Dictionary<string, string>();
                string name = file.Substring(0, file.IndexOf(".")).ToLower();
                this.lang.Add(name, new Dictionary<string, string>());
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(Path.Combine(this.langPath, file));
                }
                catch (Exception e)
                {
                    throw new UnityBulletinLocalizationException(string.Format("Failed to load localization file: {0}", file), e);
                }

                try
                {
                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Localization/String");

                    foreach (XmlNode node in nodes)
                    {
                        this.lang[name].Add(node.Attributes["Name"].Value, node.InnerText);
                    }
                }
                catch (Exception e)
                {
                    throw new UnityBulletinLocalizationException(string.Format("Failed to parse localization file: {0}", file), e);
                }
            }
        }

        #endregion Public Methods
    }
}