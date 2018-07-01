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

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UnityBulletin.Library.Data.DatabaseFactory;
using UnityBulletin.Library.Data.QueriesFactory;

namespace UnityBulletin.Drivers.MySql
{
    /// <summary>
    /// MySQL database driver.
    /// </summary>
    public class Driver : Database
    {
        /// <summary>
        /// Creates new IDbConnection instance.
        /// </summary>
        /// <returns>new IDbConnection instance</returns>
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <returns>new IDbCommand instance</returns>
        public override IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        /// <summary>
        /// Creates new open IDbConnection instance.
        /// </summary>
        /// <returns>new open IDbConnection instance</returns>
        public override IDbConnection CreateOpenConnection()
        {
            MySqlConnection connection = (MySqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <param name="commandText">string; SQL query statement</param>
        /// <param name="connection">IDbConnection; open IDbConnection instance</param>
        /// <param name="prms">IDataParameterCollection; parameter collection</param>
        /// <returns>new IDbCommand instance</returns>
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection, IDataParameterCollection prms)
        {
            MySqlCommand command = (MySqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (MySqlConnection)connection;
            command.CommandType = CommandType.Text;
            foreach (IDataParameter prm in prms) command.Parameters.Add(prm);

            return command;
        }

        /// <summary>
        /// Creates new IDbCommand instance.
        /// </summary>
        /// <param name="commandText">string; SQL query statement</param>
        /// <param name="connection">IDbConnection; open IDbConnection instance</param>
        /// <returns>new IDbCommand instance</returns>
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            MySqlCommand command = (MySqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (MySqlConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        /// <summary>
        /// Creates new IDataParameter instance.
        /// </summary>
        /// <param name="parameterName">string; parameter name</param>
        /// <param name="parameterValue">string; parameter value</param>
        /// <returns>new IDataParameter instance</returns>
        public override IDataParameter CreateParameter(string parameterName, string parameterValue)
        {
            return new MySqlParameter(parameterName, parameterValue);
        }
    }

    /// <summary>
    /// Queries driver.
    /// </summary>
    public class QueriesDriver : Queries
    {
        /// <summary>
        /// Returns specified SQL query statement.
        /// </summary>
        /// <param name="statement">SqlStatement; SQL query statement to return</param>
        /// <returns>string; SQL query statement</returns>
        public override string GetSqlStatement(SqlStatement statement)
        {
            string retVal = string.Empty;

            return retVal;
        }
    }
}