using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlEx
{
    public class Plink
    {
        /// <summary>
        /// Get the Starbuzz customer data as an XDocument
        /// </summary>
        /// <returns>XDocument with the Starbuzz data</returns>
        static XDocument GetStarbuzzData()
        {
            /* You can use an XDocument to create an XML file, and that includes XML
            * files you can read and write using DataContractSerializer.
            *
            * An XMLDocument object represents an XML document. It's part of the
            * System.Xml.Linq namespace.
            *
            * Use XElement objects to create elements under the XML tree.
            */
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Starbuzz Customer Loyalty Data"),
                new XElement("starbuzzData",
                    new XAttribute("storeName", "Park Slope"),
                    new XAttribute("location", "Brooklyn, NY"),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Janet Venutian"),
                            new XElement("zip", 11215)),
                        new XElement("favoriteDrink", "Choco Macchiato"),
                        new XElement("moneySpent", 255),
                        new XElement("visits", 50)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Liz Nelson"),
                            new XElement("zip", 11238)),
                        new XElement("favoriteDrink", "Double Cappuccino"),
                        new XElement("moneySpent", 150),
                        new XElement("visits", 35)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Matt Franks"),
                            new XElement("zip", 11217)),
                        new XElement("favoriteDrink", "Zesty Lemon Chai"),
                        new XElement("moneySpent", 75),
                        new XElement("visits", 15)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Joe Ng"),
                            new XElement("zip", 11217)),
                        new XElement("favoriteDrink", "Banana Split in a Cup"),
                        new XElement("moneySpent", 60),
                        new XElement("visits", 10)),
                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Sarah Kalter"),
                            new XElement("zip", 11215)),
                        new XElement("favoriteDrink", "Boring Coffee"),
                        new XElement("moneySpent", 110),
                        new XElement("visits", 15))));
            return doc;
        }

        /// <summary>
        /// Save the Starbuzz data to an XML file and load it again.
        /// </summary>
        /// <param name="filename">Filename to write the data to</param>
        static void SaveDataToAnXmlFile(string filename)
        {
            XDocument doc = GetStarbuzzData();
            doc.Save(filename);
        }

        /// <summary>
        /// Query the data and print the results to the console
        /// <param name="doc">XDocument with Starbuzz customer loyalty data loaded</param>
        /// </summary>
        static void QueryTheData(XDocument doc)
        {
            // Do a simple query and print the results to the console
            var data = from item in doc.Descendants("person")
                       select new
                       {
                           drink = item.Element("favoriteDrink").Value,
                           moneySpent = item.Element("moneySpent").Value,
                           zipCode = item.Element("personalInfo").Element("zip").Value
                       };
            foreach (var p in data)
                Console.WriteLine(p.ToString());
            // Do a more complex query and print the results to the console
            var zipcodeGroups = from item in doc.Descendants("person")
                                group item.Element("favoriteDrink").Value
                                by item.Element("personalInfo").Element("zip").Value
                                    into zipcodeGroup
                                    select zipcodeGroup;
            foreach (var group in zipcodeGroups)
                Console.WriteLine("{0} favorite drinks in {1}",
                                group.Distinct().Count(), group.Key);
        }

        public static void Ex7Execute()
        {
            // Save the Starbuzz data
            SaveDataToAnXmlFile("starbuzzdata.xml");

            // Read the XML data from starbuzzdata.xml
            XDocument starbuzzData = XDocument.Load("starbuzzdata.xml");

            // Query the data that was loaded
            QueryTheData(starbuzzData);

            // Don't quit until the user presses a key (just to make it easier to run in the
            // Visual Studio debugger -- since this is a learning exercise)
            Console.ReadKey();
        }

    }
}