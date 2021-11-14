using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace orm
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Type prod = typeof(Produto);

            //command = DeleteScript(prod, 1);
            command = SelectScript(prod);
            int id = 0;
            Expression<Func<Produto, bool>> expression = (p) => p.Nome == "Pedro" & p.Id == id;

            foreach (var item in expression.)
            {
                System.Console.WriteLine(item.);
            }

            //System.Console.WriteLine(command);
        }

        public static string DeleteScript(Type type, int id)
        {
            var table = GetDMTable(type);
            var key = GetDMKey(type);

            return $"DELETE FROM {table.TableName} WHERE {key.FieldName} = {id}";
        }

        public static string SelectScript(Type type)
        {
            var table = GetDMTable(type);
            var columns = GetDMColumns(type);

            StringBuilder command = new StringBuilder()
                .Append(" SELECT ")
                .Append(string.Join(", ", columns.Select(s => s.FieldName)))
                .AppendFormat(" FROM {0}", table.TableName)
                .Append(" WHERE 1=1 ");

            return command.ToString();
        }

        // x => x.Nome == "Pedro"
        public static string SelectScript(Type type, Tuple<DMColumn, string> value)
        {
            var table = GetDMTable(type);
            var columns = GetDMColumns(type);

            StringBuilder command = new StringBuilder()
                .Append(" SELECT ")
                .Append(string.Join(", ", columns.Select(s => s.FieldName)))
                .AppendFormat(" FROM {0}", table.TableName)
                .Append(" WHERE 1=1 ")
                .Append($" AND {value.Item1.FieldName} = {value.Item2}");

            return command.ToString();
        }

        public static DMTable GetDMTable(Type type) => type.GetCustomAttributes()
            .OfType<DMTable>()
            .FirstOrDefault();

        public static DMColumn[] GetDMColumns(Type type) => type.GetProperties()
            .SelectMany(s => s.GetCustomAttributes())
            .OfType<DMColumn>()
            .ToArray();

        public static DMColumn GetDMKey(Type type) => type.GetProperties()
            .SelectMany(s => s.GetCustomAttributes())
            .OfType<DMColumn>()
            .Where(w => w.GetType() == typeof(DMKey))
            .FirstOrDefault();
    }

    public class DMTable : Attribute
    {
        public string TableName { get; set; }

        public DMTable(string tableName)
        {
            this.TableName = tableName;
        }
    }

    public class DMColumn : Attribute
    {
        public string FieldName { get; set; }

        public DMColumn(string field)
        {
            this.FieldName = field;
        }

        public bool Required { get; set; }
        public string TypeField { get; set; }    
    }


    public class DMKey : DMColumn
    {
        public DMKey(string field) 
            : base (field) { }

        public bool AutoIncrement { get; set; } = true;
    }

    // EXEMPLO
    [DMTable("tb_produto")]
    public class Produto
    {
        [DMKey("id_produto", Required = true, TypeField = "int")]
        public int Id { get; set; }

        [DMColumn("nm_produto", Required = true, TypeField = "varchar(255)")]
        public string Nome { get; set; }

        [DMColumn("ds_produto", TypeField = "varchar(800)")]
        public string Descricao { get; set; }

        [DMColumn("ds_categoria", TypeField = "varchar(255)")]
        public string Categoria { get; set; }

        [DMColumn("vl_preco", TypeField = "decimal(15, 2)")]
        public double Preco { get; set; }
        
        [DMColumn("qtd_estoque", TypeField = "int")]
        public int QtdEstoque { get; set; }

        [DMColumn("vl_avaliacao", TypeField = "decimal(15, 2)")]
        public double Avaliacao { get; set; }
    }
}
