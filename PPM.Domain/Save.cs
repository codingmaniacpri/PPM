using System;
using System.IO;
using System.Xml.Serialization;
using PPM.Model;

namespace PPM.Domain
{
    public class Save
    {
        public void SaveToXML()
        {
            ProjectsRepo objProjectRepo = new();
            EmployeeRepo objemprepo = new();
            RoleRepo objrolerepo = new();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Projects>));
            using (var writer = new StreamWriter("SaveData.xml"))
            {
                serializer.Serialize(writer, objProjectRepo.ListAll());

                serializer = new XmlSerializer(typeof(List<Employees>));
                serializer.Serialize(writer,objemprepo.ListAll());
 
                serializer = new XmlSerializer(typeof(List<Role>));
                serializer.Serialize(writer, objrolerepo.ListAll());
            }
        }

        
    }
}
