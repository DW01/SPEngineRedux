using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEngineReduxLibrary.Readers
{
    class TeamReader : ReaderBase
    {
        enum TeamIDEnumerator
        {
            // Enumerate Team IDs here.

            TEAM_ID_1 = 1,
            TEAM_ID_2 = 2,
            TEAM_ID_3 = 3,
            TEAM_ID_4 = 4,
            TEAM_ID_5 = 5,
            TEAM_ID_6 = 6,
            TEAM_ID_7 = 7,
            TEAM_ID_8 = 8,
            TEAM_ID_9 = 9,
            TEAM_ID_N = 0 // Neutral team, used for passive / environmental mobs.
        }

        TeamIDEnumerator TeamIDs = new TeamIDEnumerator();
        // Load teams based on ID.
        public void OpenTeamsByID(TeamsDirectory)
        {
            if (!TeamIDs.Equals(0))
            {
                // TODO: Logic here once TeamReader is loading all Team JSON.
            }
            else
            {
                // TODO: Load neutral mobs last.
            }
        }
    }
}
