using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace ClassLibrary.CBCData
{
    public class CBCDataSet : DataSet
    {
        public readonly DataSet dataSet = new();
        private DataTable customerTable = new(CBCDataObjects.Constants.CustomerTableName);
        private DataTable orderTable = new(CBCDataObjects.Constants.OrderTableName);
        private DataTable itemTable = new(CBCDataObjects.Constants.ItemTableName);
        private DataTable orderItemTable = new(CBCDataObjects.Constants.OrderItemTableName);

        private readonly Exception IdentityColumnRuleViolation = new Exception("Idenity Columns must be unique and non-nullable.");
        private readonly Exception UnreachableCodeInCreateTable = new Exception("Reached unreachable code in Create Table.");

        private enum ColumnType
        {
            Identity,
            Integer,
            String,
            DateTime
        }

        public CBCDataSet()
        {
            dataSet = CreateTableSchema();
        }

        private DataSet CreateTableSchema()
        {
            DataSet dataSet = new();

            #region Customer
            DataColumn customerCustomerIdColumn =
                CreateIdentityDataColumn(name: "CustomerID");

            customerTable.Columns.Add(customerCustomerIdColumn);

            customerTable.Columns.Add(
                column: CreateDataColumn(name: "Name",
                                         caption: "Name",
                                         type: ColumnType.String,
                                         isUnique: false,
                                         isNullable: false));
            customerTable.Columns.Add(
                column: CreateDataColumn(name: "Telephone",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: true));
            customerTable.Columns.Add(
                column: CreateDataColumn(name: "Email",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: true));
            customerTable.Columns.Add(
                column: CreateDataColumn(name: "WKSOrderNumber",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: true));
            customerTable.Columns.Add(
                column: CreateDataColumn(name: "PickupTime",
                                         type: ColumnType.DateTime,
                                         isUnique: true,
                                         isNullable: true));

            DataColumn[] customerPrimaryKeyColumns = new DataColumn[1];
            customerPrimaryKeyColumns[0] = customerCustomerIdColumn;
            customerTable.PrimaryKey = customerPrimaryKeyColumns;
            #endregion

            #region OrderTable
            DataColumn orderOrderIdColumn =
                CreateIdentityDataColumn(name: "OrderID");
            orderTable.Columns.Add(orderOrderIdColumn);

            DataColumn dataColumnOrderCustomerId =
                CreateDataColumn(name: "CustomerID",
                                 caption: "Name",
                                 type: ColumnType.Integer,
                                 isUnique: false,
                                 isNullable: false);
            orderTable.Columns.Add(dataColumnOrderCustomerId);

            DataColumn dataColumnOrderSquareId =
                CreateDataColumn(name: "SquareID",
                                 type: ColumnType.String,
                                 isUnique: true,
                                 isNullable: false);
            orderTable.Columns.Add(dataColumnOrderSquareId);

            DataColumn[] orderPrimaryKeyColumns = new DataColumn[3];
            orderPrimaryKeyColumns[0] = orderOrderIdColumn;
            orderPrimaryKeyColumns[1] = dataColumnOrderCustomerId;
            orderPrimaryKeyColumns[2] = dataColumnOrderSquareId;
            orderTable.PrimaryKey = orderPrimaryKeyColumns;
            #endregion

            #region ItemTable
            DataColumn dataColumnItemItemId =
                CreateIdentityDataColumn(name: "ItemID");
            itemTable.Columns.Add(dataColumnItemItemId);

            itemTable.Columns.Add(
                column: CreateDataColumn(name: "SKU",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: false));
            itemTable.Columns.Add(
                column: CreateDataColumn(name: "Description",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: false));
            itemTable.Columns.Add(
                column: CreateDataColumn(name: "ShortDescription",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: false));
            itemTable.Columns.Add(
                column: CreateDataColumn(name: "SizeDescription",
                                         caption: "Size",
                                         type: ColumnType.String,
                                         isUnique: false,
                                         isNullable: false));
            itemTable.Columns.Add(
                column: CreateDataColumn(name: "SquareID",
                                         type: ColumnType.String,
                                         isUnique: true,
                                         isNullable: false));

            DataColumn[] itemPrimaryKeyColumns = new DataColumn[1];
            itemPrimaryKeyColumns[0] = dataColumnItemItemId;
            itemTable.PrimaryKey = itemPrimaryKeyColumns;
            #endregion

            #region OrderItemTable
            DataColumn orderItemOrderIdColumn = CreateDataColumn(
                                                name: "OrderID",
                                                type: ColumnType.Integer,
                                                isUnique: false,
                                                isNullable: false);
            DataColumn orderItemItemIdColumn = CreateDataColumn(
                                                name: "ItemID",
                                                type: ColumnType.Integer,
                                                isUnique: false,
                                                isNullable: false);
            orderItemTable.Columns.Add(column: orderItemOrderIdColumn);
            orderItemTable.Columns.Add(column: orderItemItemIdColumn);

            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = orderItemOrderIdColumn;
            PrimaryKeyColumns[1] = orderItemItemIdColumn;
            orderItemTable.PrimaryKey = PrimaryKeyColumns;
            #endregion

            dataSet.Tables.Add(customerTable);
            dataSet.Tables.Add(orderTable);
            dataSet.Tables.Add(itemTable);
            dataSet.Tables.Add(orderItemTable);

            CreateDataRelation(parentTable: customerTable,
                               childTable: orderTable,
                               parentColumn: customerCustomerIdColumn,
                               childColumn: dataColumnOrderCustomerId);

            CreateDataRelation(parentTable: orderTable,
                               childTable: orderItemTable,
                               parentColumn: orderOrderIdColumn,
                               childColumn: orderItemItemIdColumn);

            return dataSet;
        }

        private DataColumn CreateDataColumn(string name, ColumnType type, bool isUnique, bool isNullable, string caption = "")
        {
            DataColumn dataColumn;
            dataColumn = new DataColumn();
            dataColumn.AllowDBNull = isNullable;
            dataColumn.ColumnName = name;
            dataColumn.Unique = isUnique;
            if (caption != "")
            {
                dataColumn.Caption = caption;
            }
            switch (type)
            {
                case ColumnType.Identity:
                    if (!isUnique || isNullable)
                    {
                        throw IdentityColumnRuleViolation;
                    }
                    else
                    {
                        dataColumn.DataType = System.Type.GetType("System.Int32");
                        dataColumn.AutoIncrement = true;
                        dataColumn.ReadOnly = true;
                    };
                    break;
                case ColumnType.Integer:
                    dataColumn.DataType = System.Type.GetType("System.Int32");
                    break;
                case ColumnType.String:
                    dataColumn.DataType = System.Type.GetType("System.String");
                    break;
                case ColumnType.DateTime:
                    dataColumn.DataType = System.Type.GetType("System.DateTime");
                    break;
                default:
                    throw UnreachableCodeInCreateTable;
            };
            return dataColumn;
        }

        private DataColumn CreateIdentityDataColumn(string name)
        {
            return CreateDataColumn(name: name,
                                    caption: name,
                                    type: ColumnType.Identity,
                                    isUnique: true,
                                    isNullable: false);
        }

        private static void CreateDataRelation(DataTable parentTable,
                                               DataTable childTable, 
                                               DataColumn parentColumn,
                                               DataColumn childColumn)
        {
            childTable.ParentRelations.Add(new DataRelation(
                relationName: "FK+"
                                + parentTable.TableName
                                + "_"
                                + childTable.TableName,
                parentColumn: parentColumn,
                childColumn: childColumn)); ;
        }

        #region InternetFunctions
        public static DataTable ObjectToData(DataTable dataTable, object o)
        {
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);

            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                f.GetValue(o, null);
                dataTable.Columns.Add(f.Name, f.PropertyType);
                dataTable.Rows[0][f.Name] = f.GetValue(o, null);
            });
            return dataTable;
        }
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion
    }
}