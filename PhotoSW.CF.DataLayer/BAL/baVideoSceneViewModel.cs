using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoSceneViewModel
        {
        public int Id { get; set; }
        public videoscene VideoScene { get; set; }
        public videosceneobject VideoSceneObject { get; set; }
        public List<videosceneobject> ListVideoSceneObject { get; set; }
        public List<videoobjectfilemapping> ListVideoObjectFileMapping { get; set; }
        public videoobjectfilemapping VideoObjectFileMapping { get; set; }
        public bool IsActive { get; set; }

      




        }
    }
