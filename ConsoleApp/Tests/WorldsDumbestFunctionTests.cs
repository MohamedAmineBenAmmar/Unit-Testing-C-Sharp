using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        // Naming convention to respect in testing: ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_IsPickatchu_ReturnsString()
        {
            try
            {
                // Arrange - Go get your variables, whatever you need, your classes, go get your functions
                int num = 0;
                WorldsDumbestFunction worldsDumbestFunction = new WorldsDumbestFunction();

                // Act - Executes the function
                string result = worldsDumbestFunction.IsPickatchu(num);

                // Assert - Whatever is returned is it what you want
                if (result == "PICKATCHU")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction_IsPickatchu_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction_IsPickatchu_ReturnsString");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
