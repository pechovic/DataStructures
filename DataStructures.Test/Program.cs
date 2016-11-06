/*
This file serves only to debug the tests from Visual Studio Code

*/
namespace DataStructures.Test
{

    public class Program {
        public static void Main(string[] args) {
            var tests = new HeapTest();
            tests.Inset_Integers_Ok();
            tests.Insert_MinOrder_Ok();
            tests.Insert_MaxOrder_Ok();
        }
    }
}