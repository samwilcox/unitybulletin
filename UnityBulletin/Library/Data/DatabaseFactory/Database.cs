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
    /// Database factory abstract class.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        public string connectionString;

        #region Abstract Methods

        /// <summary>
        /// Creates new IDbConnection instance.
        /// </summary>
        /// <returns>new IDbConnection instance</returns>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <returns>new IDbCommand instance</returns>
        public abstract IDbCommand CreateCommand();

        /// <summary>
        /// Creates new open IDbConnection instance.
        /// </summary>
        /// <returns>new open IDbConnection instance</returns>
        public abstract IDbConnection CreateOpenConnection();

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <param name="commandText">string; SQL query statement</param>
        /// <param name="connection">IDbConnection; open IDbConnection instance</param>
        /// <param name="prms">IDataParameterCollection; parameter collection</param>
        /// <returns>new IDbCommand instance</returns>
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection, IDataParameterCollection prms);

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <param name="commandText">string; SQL query statement</param>
        /// <param name="connection">IDbConnection; open IDbConnection instance</param>
        /// <returns>new IDbCommand instance</returns>
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);

        /// <summary>
        /// Creates new IDataParameter instance.
        /// </summary>
        /// <param name="parameterName">string; parameter name</param>
        /// <param name="parameterValue">string; parameter value</param>
        /// <returns>new IDataParameter instance</returns>
        public abstract IDataParameter CreateParameter(string parameterName, string parameterValue);

        #endregion Abstract Methods
    }
}