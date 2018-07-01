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
using System.Data;
using System.Linq;
using System.Web;

namespace UnityBulletin.Library.Data.DatabaseFactory
{
    /// <summary>
    /// Database abstraction layer.
    /// </summary>
    public class DatabaseAbstraction : DataWorker
    {
        #region Public Methods

        /// <summary>
        /// Returns a single row of results from the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        /// <param name="prms">IDataParameterCollection; parameter collection</param>
        /// <returns>new Dictionary(string, object) collection</returns>
        public Dictionary<string, object> GetRow(string query, IDataParameterCollection prms)
        {
            Dictionary<string, object> retVal = new Dictionary<string, object>();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection, prms))
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    for (int i = 0; i < reader.FieldCount; i++) retVal.Add(reader.GetName(i), reader.GetValue(i));
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to get a single row of results from the database.", e);
            }

            return retVal;
        }

        /// <summary>
        /// Returns a single row of results from the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        /// <returns>new Dictionary(string, object) collection</returns>
        public Dictionary<string, object> GetRow(string query)
        {
            Dictionary<string, object> retVal = new Dictionary<string, object>();

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection))
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    for (int i = 0; i < reader.FieldCount; i++) retVal.Add(reader.GetName(i), reader.GetValue(i));
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to get a single row of results from the database.", e);
            }

            return retVal;
        }

        /// <summary>
        /// Returns multiple rows of results from the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        /// <param name="prm">IDataParameterCollection; parameter collection</param>
        /// <returns>new Dictionary(int, Dictionary(string, object)) collection</returns>
        public Dictionary<int, Dictionary<string, object>> GetRows(string query, IDataParameterCollection prm)
        {
            Dictionary<int, Dictionary<string, object>> retVal = new Dictionary<int, Dictionary<string, object>>();
            int x = 0;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection, prm))
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++) data.Add(reader.GetName(i), reader.GetValue(i));
                        retVal.Add(x, data);
                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to get multiple rows of results from the database.", e);
            }

            return retVal;
        }

        /// <summary>
        /// Returns multiple rows of results from the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        /// <returns>new Dictionary(int, Dictionary(string, object)) collection</returns>
        public Dictionary<int, Dictionary<string, object>> GetRows(string query)
        {
            Dictionary<int, Dictionary<string, object>> retVal = new Dictionary<int, Dictionary<string, object>>();
            int x = 0;

            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection))
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++) data.Add(reader.GetName(i), reader.GetValue(i));
                        retVal.Add(x, data);
                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to get multiple rows of results from the database.", e);
            }

            return retVal;
        }

        /// <summary>
        /// Executes "non-query" on the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        /// <param name="prms">IDataParameterCollection; parameter collection</param>
        public void NonQuery(string query, IDataParameterCollection prms)
        {
            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection, prms))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to perform non-query on the database server.", e);
            }
        }

        /// <summary>
        /// Executes "non-query" on the database.
        /// </summary>
        /// <param name="query">string; SQL query statement</param>
        public void NonQuery(string query)
        {
            try
            {
                using (IDbConnection connection = database.CreateOpenConnection())
                using (IDbCommand command = database.CreateCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to perform non-query on the database server.", e);
            }
        }

        #endregion Public Methods
    }
}