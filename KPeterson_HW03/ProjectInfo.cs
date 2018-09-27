using System;
using System.Collections.ObjectModel;

namespace KPeterson_HW03
{
    public class ProjectInfo
    {
        private ObservableCollection<Projects> _projects;


        public ProjectInfo()
        {
            _projects = new ObservableCollection<Projects>();


            // Insert customer and corresponding order information into 
            Projects c = new Projects() { ID =1 , Name = "Project Cool" };
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "UX" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "DB" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 11, 10), Skill = "Cloud" });
            _projects.Add(c);


            c = new Projects() { ID = 2, Name = "Project Awesome" };
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "CSS" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "HTML" });
            _projects.Add(c);


            c = new Projects() { ID = 3, Name = "Project NANO" };
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "HTML" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "SEO" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 11, 10), Skill = "JSON" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 11, 10), Skill = "PHP" });
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 11, 10), Skill = "CSS" });
            _projects.Add(c);


            c = new Projects() { ID = 4, Name = "Project Cheese" };
            c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "JS" });
            _projects.Add(c);
        }


        public ObservableCollection<Projects> Project
        {
            get { return _projects; }
        }
    }
}
