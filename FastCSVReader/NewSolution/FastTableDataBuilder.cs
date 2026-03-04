using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var newRow = new FastRow();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    newRow.AssignCell(column, true);
                }
                else if (valueAsString == "FALSE")
                {
                    newRow.AssignCell(column, false);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    newRow.AssignCell(column, valueAsDecimal);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRow.AssignCell(column, valueAsInt);
                }
                else
                {
                    newRow.AssignCell(column, valueAsString);
                }
            }

            resultRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }

    public class FastRow
    {
        private Dictionary<string, int> _intData = new();
        private Dictionary<string, bool> _boolData = new();
        private Dictionary<string, decimal> _decimalData = new();
        private Dictionary<string, string> _stringData = new();

        public void AssignCell(string columnName, bool value) => _boolData[columnName] = value;
        public void AssignCell(string columnName, int value) => _intData[columnName] = value;
        public void AssignCell(string columnName, decimal value) => _decimalData[columnName] = value;
        public void AssignCell(string columnName, string value) => _stringData[columnName] = value;

        public object GetAtColumn(string columnName)
        {
            if (_boolData.ContainsKey(columnName))
            {
                return _boolData[columnName];
            }

            if (_intData.ContainsKey(columnName))
            {
                return _intData[columnName];
            }

            if (_decimalData.ContainsKey(columnName))
            {
                return _decimalData[columnName];
            }

            if (_stringData.ContainsKey(columnName))
            {
                return _stringData[columnName];
            }
            
            return null;
        }
    }

    public class FastTableData : ITableData
    {
        private readonly List<FastRow> _rows;
        public int RowCount => _rows.Count;
        public IEnumerable<string> Columns { get; }

        public FastTableData(IEnumerable<string> columns, List<FastRow> rows)
        {
            _rows = rows;
            Columns = columns;
        }

        public object GetValue(string columnName, int rowIndex)
        {
            return _rows[rowIndex].GetAtColumn(columnName);
        }
    }
}
