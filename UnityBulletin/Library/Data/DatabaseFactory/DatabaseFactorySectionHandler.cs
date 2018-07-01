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
using System.Configuration;
using System.Linq;
using System.Web;

namespace UnityBulletin.Library.Data.DatabaseFactory
{
    /// <summary>
    /// Database factory configuration section handler.
    /// </summary>
    public sealed class DatabaseFactorySectionHandler : ConfigurationSection
    {
        /// <summary>
        /// Name configuration property.
        /// </summary>
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }

        /// <summary>
        /// ConnectionStringName configuration property.
        /// </summary>
        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }

        /// <summary>
        /// ConnectionString getter.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception e)
                {
                    throw new UnityBulletinDatabaseException("No database connection strings found in the database configurations.", e);
                }
            }
        }
    }
}