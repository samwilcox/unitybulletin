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
using System.Linq;
using System.Web;

namespace UnityBulletin.Library.Data.QueriesFactory
{
    /// <summary>
    /// Queries factory worker class.
    /// </summary>
    public class QueriesWorker
    {
        /// <summary>
        /// Queries object instance.
        /// </summary>
        private static Queries _queries = null;

        /// <summary>
        /// Default class constructor.
        /// </summary>
        static QueriesWorker()
        {
            try
            {
                _queries = QueriesFactory.CreateQueries();
            }
            catch (Exception e)
            {
                throw new UnityBulletinDatabaseException("Failed to create new Queries iinstance.", e);
            }
        }

        /// <summary>
        /// Returns new Queries object instance.
        /// </summary>
        public static Queries queries
        {
            get { return _queries; }
        }
    }
}