using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Dynamix")]
    [FameDescription("Event")]
    public class Event : Entity
    {
        [FameProperty(Name = "parent") Opposite = "children"]
        public Event parent { get; set; }

        private List<Event> children = new List<Event>();        [FameProperty(Name = "children", Opposite = "parent")]        public List Events        {            get { return Events; }            set { Events = value; }        }        public void AddEvent(Event one)        {            Events.Add(one);        }






    }
}