using System;
using System.Data.SqlClient;
using Dapper;

namespace aspcore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program.tesInsert();
            //Program.testInsertMulit();
            // Program.test_del();
            Program.test_update();
        }
        static void tesInsert() {
            //测试插入单条数据
            var content = new Content {title="标题",content="内容" };

            //数据库连接
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123456;Initial Catalog=LearnNet;Pooling=true;Max Pool Size=100;")) {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }

        //插入多条数据，即插入列表
        static void testInsertMulit() {
            var contents = new System.Collections.Generic.List<Content>() {
            new Content{title="批量数据1",content="批量第一个数据" },new Content{title="批量数据2",content="批量第二个数据" }
            };

            //数据库连接
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123456;Initial Catalog=LearnNet;Pooling=true;Max Pool Size=100;")) {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }

        }


        //测试单删除
        static void test_del() {
            var content = new Content
            {
                id = 2
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123456;Initial Catalog=LearnNet;Pooling=true;Max Pool Size=100;"))
            {
                string sql = @"delete from content where id=@id";
                var result = conn.Execute(sql,content);
                Console.WriteLine($"删除了{result}条数据！");
            }
        }

        //测试批量删除,删除列表 list
        static void test_del_mult() { 
        
        }

        //测试修改
        static void test_update() {
            var content = new Content { id = 1 ,content="修改了标题",title="修改了内容"};

            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123456;Initial Catalog=LearnNet;Pooling=true;Max Pool Size=100;")) {
                var sql_update = @"update content set title=@title ,content=@content where id=@id";
                var result = conn.Execute(sql_update,content);
                Console.WriteLine($"修改了{result}条数据！");

            }
        }
        //测试多修改，修改列表
        static void test_update_mult() { 
        }


        //测试查询 
    }
}
