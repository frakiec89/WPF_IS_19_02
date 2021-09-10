using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using WPF_IS_19_02.View.ModelView;

namespace WPF_IS_19_02.View
{
    partial class ControllerMaterial
    {
        public static List<View.ModelView.ViewMaterial> GetViewMaterial()
        {

            try
            {
                DB.dEntities entities = new DB.dEntities();

                var material = entities.Materials.ToList();

                List<View.ModelView.ViewMaterial> views = new List<ModelView.ViewMaterial>();

                foreach (var item in material)
                {
                    views.Add(new ModelView.ViewMaterial(item));
                }

                return views;
            }
            catch
            {
                throw new Exception("Error db");
            }

        }

        internal static bool AddMateril(string name, string description , string minCount, 
            string packageCount,
            string priceR,
            object image, 
            object sI, 
            object typeMaterial)
        {
            DB.Materials neWmaterials = new DB.Materials();
            try
            {
                neWmaterials = new DB.Materials();
                View.ModelView.Image im = image as View.ModelView.Image;

                neWmaterials.ImagePath = @"/Image\" + im.NameImage;
                neWmaterials.Name = name;
                neWmaterials.Price = Convert.ToInt32(priceR);
                neWmaterials.MinCount = Convert.ToInt32(minCount);
                neWmaterials.CountPerPack = Convert.ToInt32(packageCount);
                neWmaterials.Id_MaterialType = GetIdMaterialType(typeMaterial as string);
                neWmaterials.Id_MaterialSI = GetIdMaterialSy(sI as string);
                neWmaterials.Discriptions = description;
                neWmaterials.Id_MaterialColor = 1;
                neWmaterials.Id_MaterialStandart = 1;
            }
            catch
            {
                throw new Exception("Ошибка входных параметров");
            }

            if(neWmaterials==null)
            {
                return false;
            }
            try
            {
                DB.dEntities entities = new DB.dEntities();
                entities.Materials.Add(neWmaterials);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("единицы измерения  не найдены  в бд");
            }
        }

        private static int GetIdMaterialSy(string name)
        {
            try
            {
                DB.dEntities entities = new DB.dEntities();
                return entities.MaterialSI.Where(x => x.Name == name).First().Id;
            }
            catch
            {
                throw new Exception("единицы измерения  не найдены  в бд");
            }
        }

        internal static void Remove(DB.Materials materials)
        {
            try
            {
                DB.dEntities entities = new DB.dEntities();
                entities.Materials.Remove(entities.Materials.Find(materials.Id));
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Удаление  не получилось");
            }
        }

        private static int GetIdMaterialType(string name)
        {
           try
            {
              DB.dEntities entities = new DB.dEntities();
              return  entities.MaterialTypes.Where(x => x.Name == name).First().Id;
            }
            catch
            {
                throw new Exception("Материал не найден  в бд");
            }
        }

        internal static bool ChaneMateril(string name, string description, string minCount,
         string packageCount,
         string priceR,
         object image,
         object sI,
         object typeMaterial , DB.Materials materials)
        {
            DB.dEntities entities = new DB.dEntities();


            DB.Materials neWmaterials = entities.Materials.Find(materials.Id);

            try
            {
                View.ModelView.Image im = image as View.ModelView.Image;
                neWmaterials.ImagePath = @"/Image\" + im.NameImage;
                neWmaterials.Name = name;
                neWmaterials.Price = Convert.ToInt32(priceR);
                neWmaterials.MinCount = Convert.ToInt32(minCount);
                neWmaterials.CountPerPack = Convert.ToInt32(packageCount);
                neWmaterials.Id_MaterialType = GetIdMaterialType(typeMaterial as string);
                neWmaterials.Id_MaterialSI = GetIdMaterialSy(sI as string);
                neWmaterials.Discriptions = description;
            }
            catch
            {
                throw new Exception("Ошибка входных параметров");
            }

            if (neWmaterials == null)
            {
                return false;
            }
            try
            {
                entities.Materials.AddOrUpdate(neWmaterials);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("единицы измерения  не найдены  в бд");
            }
        }
    }
}