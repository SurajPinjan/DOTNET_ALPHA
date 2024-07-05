public class Query
{
    public ColumWithAlias[] SelectedColumns { get; set; } = new ColumWithAlias[] { };
    public TableEntity[] SelectedTables { get; set; } = new TableEntity[] { };
    public WhereEntity[] Where { get; set; } = new WhereEntity[] { };
    public SortEntity[] SortColumns { get; set; } = new SortEntity[] { };
}

public class ColumWithAlias
{
    public string ColumnName { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public bool ToFormat { get; set; } = false;
    public string TableName { get; set; } = string.Empty;
}


public class SortEntity
{
    public string ColumnName { get; set; } = string.Empty;
    public bool Ascending { get; set; } = true;
}

public class TableEntity
{
    public string TableName { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
}

public class WhereEntity
{
    public string ColumnName { get; set; } = string.Empty;
    public Operators Operator { get; set; } = Operators.Equals;
    public string Value { get; set; } = string.Empty;
}

public enum Operators
{
    Equals = 0,
    NotEquals = 1,
    GreaterThan = 2,
    LessThan = 3,
    GreaterThanOrEquals = 4,
    LessThanOrEquals = 5,
    Like = 6,
    NotLike = 7,
    In = 8,
    NotIn = 9
}

