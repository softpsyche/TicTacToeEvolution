using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    public static class TableRowExtensions
    {
        public static void FillInstance<T>(this TableRow tableRow, T instance)
            where T : class
        {
            typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty)
                .Join(tableRow.Keys, a => a.Name, a => a, (a, b) => new { Property = a, TableRow = tableRow })
                .ForEach(a => a.Property.SetValue(instance, Convert.ChangeType(a.TableRow[a.Property.Name], a.Property.PropertyType)));             
        }
    }
}
