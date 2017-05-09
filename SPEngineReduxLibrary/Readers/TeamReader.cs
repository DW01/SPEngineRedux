using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEngineReduxLibrary.Readers
{
    public class Unit : Cell
    {
        // Cell properties.
        public string UnitName { get; set; } // String. Name of cell, used in Legend Cells and user interface.
        public string UnitID { get; set; }
        public string UnitColor { get; set; }
        public int UnitJob { get; set; }
        public string UnitTeam { get; set; }

        public bool IsUnitDead { get; set; }
        public int UnitDeathType { get; set; }

        public int UnitCurrentHP { get; set; }
        public int UnitMaxHP { get; set; }
        public int UnitCurrentMP { get; set; }
        public int UnitMaxMP { get; set; }
        public int UnitATK { get; set; }
        public int UnitDEF { get; set; }
        public int UnitINT { get; set; }
        public int UnitSPR { get; set; }
        public float UnitCritChance { get; set; }
        public float UnitEvadeChance { get; set; }
        public int UnitMove { get; set; }
        public int UnitXLevels { get; set; }
    }

    public class Team
    {
        public List<Unit> Units { get; set; }
    }

    class TeamReader : ReaderBase
    {
        public enum TeamIDEnumerator
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

        string TeamDirectory = Path.Combine(Directory.GetCurrentDirectory(), "JsonResources/Teams/");
        TeamIDEnumerator TeamIDs = new TeamIDEnumerator();

        // Load teams based on ID.
        public void OpenTeamsByID()
        {
            string TeamFile = Path.Combine(TeamDirectory, Enum.GetNames(typeof(TeamIDEnumerator)).ToString(), ".team");
            foreach (var Team in TeamDirectory)
            {
                Team UnitList = new Team();
                JObject Units = ReadJsonObject(TeamFile);

                foreach (var Unit in Units)
                {
                    Unit unit = new Unit();
                    if (!TeamIDs.Equals(0))
                    {
                        UnitList.Units.Add(unit);
                    }
                    else if (TeamIDs.Equals(0))
                    {
                        unit.UnitTeam = "0";
                        UnitList.Units.Add(unit);
                    }
                }
            }
        }
    }
}
