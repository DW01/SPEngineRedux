using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SPEngineReduxLibrary.Readers
{
    public class Cell
    {
        // Cell properties.
        public string CellName { get; set; } // String. Name of cell, used in Legend Cells and user interface.
        public string CellID { get; set; }
        public string Color { get; set; }
        public int Classification { get; set; }
        public string Alignment { get; set; }


        public bool DoesCellExist { get; set; }


        public bool IsCellPassable { get; set; }
        public bool CanOccupyCell { get; set; }
        public bool IsCellDestructible { get; set; }
        public bool BlocksRangedAttacks { get; set; }


        public bool CellHasStats { get; set; }


        public int CurrentCellHP { get; set; }
        public int MaxCellHP { get; set; }
        public int CurrentCellMP { get; set; }
        public int MaxCellMP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int INT { get; set; }
        public int SPR { get; set; }
        public float CritChance { get; set; }
        public float EvadeChance { get; set; }
        public int Move { get; set; }
        public int XLevels { get; set; }
        public int CON { get; set; }
    }

    public class CellBank
    {
        public List<Cell> Cells { get; set; }
    }

    public class CellReader : ReaderBase
    {
        // Open the default Cell Data Bank.
        string DefaultCellBank = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "JsonResources/DefaultCells.bank"));

        public void OpenDefaultCellBank()
        {
            try
            {
                var AttributeList = ReadJsonArray(DefaultCellBank);
                CellBank StockCellBank = new CellBank();

                // Try to set fields in CellBank per Cell.
                foreach (JObject CellType in AttributeList.Children())
                {
                    // For every Cell Type, make a new Cell object.
                    Cell cell = new Cell();

                    // Typecast all bool "strings" back to bools.
                    bool DoesCellExist = CellType.Value<bool>("DoesCellExist");
                    bool IsCellPassable = CellType.Value<bool>("IsCellPassable");
                    bool CanOccupyCell = CellType.Value<bool>("CanOccupyCell");
                    bool IsCellDestructible = CellType.Value<bool>("IsCellDestructible");
                    bool BlocksRangedAttacks = CellType.Value<bool>("BlocksRangedAttacks");
                    bool CellHasStats = CellType.Value<bool>("CellHasStats");

                    // Check if the Cell exists before doing anything else!
                    if (CellType != null)
                    {
                        // Add Cells to bank for each cell name.
                        foreach (JToken CellName in AttributeList.Children())
                        {
                            StockCellBank.Cells.Add(cell);
                        }
                    }
                }
            }
            catch (FileNotFoundException DefaultCellBankMissingException)
            {
                throw new FileNotFoundException("Cannot find default Cell Bank. Make sure it's present in JsonResources.", DefaultCellBankMissingException);
            }
            catch (DirectoryNotFoundException JsonResourcesMissingException)
            {
                throw new DirectoryNotFoundException("Can't access the JsonResources directory. Has it been moved or deleted?", JsonResourcesMissingException);
            }
            catch (Exception ex)
            {
                throw new IOException("Unknown error opening default Cell Bank.", ex);
            }
        }

        // Print Cells out.
        public void PrintCellsToConsole()
        {
            try
            {
                var AttributeList = ReadJsonArray(DefaultCellBank);
                foreach (JObject CellType in AttributeList.Children())
                {
                    bool CellHasStats = CellType.Value<bool>("CellHasStats");
                    if (CellHasStats == false)
                    {
                        Console.WriteLine("Found Cell \"{0}\" with Identifier \"{1}\" and hexcode \"{2}\".", CellType["CellName"].ToString(), CellType["CellID"].ToString(), CellType["Color"].ToString());
                        Console.WriteLine("Given Cell does not use statistics (CellHasStats is {0}).\n", CellType["CellHasStats"].ToString());
                    }
                    else
                    {
                        Console.WriteLine("Found Cell \"{0}\" with Identifier \"{1}\" and hexcode \"{2}\".", CellType["CellName"].ToString(), CellType["CellID"].ToString(), CellType["Color"].ToString());
                        Console.WriteLine("Given Cell uses statistics (CellHasStats is {0}).\n", CellType["CellHasStats"].ToString());
                    }
                }
            }
            catch (FileNotFoundException DefaultCellBankMissingException)
            {
                throw new FileNotFoundException("Cannot find default Cell Bank. Make sure it's present in JsonResources.", DefaultCellBankMissingException);
            }
            catch (DirectoryNotFoundException JsonResourcesMissingException)
            {
                throw new DirectoryNotFoundException("Can't access the JsonResources directory. Has it been moved or deleted?", JsonResourcesMissingException);
            }
            catch (Exception ex)
            {
                throw new IOException("Unknown error opening default Cell Bank.", ex);
            }

        }
    }
}