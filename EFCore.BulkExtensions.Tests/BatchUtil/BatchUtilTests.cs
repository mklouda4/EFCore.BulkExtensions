﻿using EFCore.BulkExtensions.SqlAdapters;
using Xunit;

namespace EFCore.BulkExtensions.Tests.BatchUtil;

public class BatchUtilTests
{
    [Fact]
    public void GetBatchSql_UpdateSqlite_ReturnsExpectedValues()
    {
        using var context = new TestContext(SqlType.Sqlite);
        (string sql, string tableAlias, string tableAliasSufixAs, _, _, _) = BulkExtensions.BatchUtil.GetBatchSql(context.Items, context, true);

        Assert.Equal("\"Item\"", tableAlias);
        Assert.Equal(" AS \"i\"", tableAliasSufixAs);
    }
}
