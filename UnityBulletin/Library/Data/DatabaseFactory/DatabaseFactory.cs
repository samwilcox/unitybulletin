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
using System.Reflection;
using System.Web;

namespace UnityBulletin.Library.Data.DatabaseFactory
{
    /// <summary>
    /// Database factory class.
    /// </summary>
    public sealed class DatabaseFactory
    {
        /// <summary>
        /// Database section handler instance.
        /// </summary>
        public static DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

        /// <summary>
        /// Default class constructor.
        /// </summary>
        private DatabaseFactory() { }

        /// <summary>
        /// Creates new Database object instance.
        /// </summary>
        /// <returns>new Database instance</returns>
        public static Database CreateDatabase()
        {
            if (sectionHandler.Name.Length == 0) throw new UnityBulletinDatabaseException("Database name is not defined in the DatabaseConfigurationSection of databse configuration.");

            try
            {
                Type database = Type.GetType(sectionHandler.Name);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                Database createdObject = (Database)constructor.Invoke(null);
                createdObject.connectionString = sectionHandler.ConnectionString;
                return createdObject;
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to instantiate the database factory.", e);
            }
        }
    }
}