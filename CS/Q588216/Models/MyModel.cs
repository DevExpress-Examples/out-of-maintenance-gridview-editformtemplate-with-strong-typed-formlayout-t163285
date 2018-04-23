using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCxGridViewDataBinding.Models {
    public class MyModel {
        public MyModel()
            : this(0) {
        }

        public MyModel(int index) {
            ModelID = index;
            ModelName = "Name" + index;
            ModelState = index % 2 == 0;
            ModelDate = DateTime.Now;
        }

        public int ModelID { get; set; }
        [Required]
        public string ModelName { get; set; }
        public Boolean? ModelState { get; set; }
        public DateTime ModelDate { get; set; }

        public static List<MyModel> GetModelList() {
            List<MyModel> l = new List<MyModel>();
            for (int i = 0; i < 100; i++) {
                l.Add(new MyModel(i));
            }
            return l;
        }

        public static void UpdateModel(List<MyModel> l, MyModel m) {
            MyModel editedModel = l.Where(x => x.ModelID == m.ModelID).First();
            editedModel.ModelName = m.ModelName;
            editedModel.ModelDate = m.ModelDate;
            editedModel.ModelState = m.ModelState;
        }

        public static void DeleteModel(List<MyModel> l, int mID) {
            l.Remove(l.Where(x => x.ModelID == mID).First());
        }

        public static void InsertModel(List<MyModel> l, MyModel m) {
            m.ModelID = l.Count + 1;
            l.Add(m);
        }
    }
}
