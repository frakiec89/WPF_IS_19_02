using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        private const double product_type1 = 1.1; // коэффициенты
        private const double product_type2 = 2.5;
        private const double product_type3 = 8.43;
        private const float material_type1 = 0.003F; // коэффициенты брака
        private const float material_type2 = 0.0012F;

        /// <summary>
        /// расчет  материалов  при  производстве
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="materialType"></param>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns>-1 если материла  или продукта нет</returns>
        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length )
        {
            // проверка  входных параметров 
            if (IsBadArgument(count , width , length))
            {
                return -1;
            }


            double coefProduct_type, coefMaterial_type;
            try // проверка  типов , поиск  коэффициентов
            {
                 coefProduct_type = GetProdutc(productType);
                 coefMaterial_type = GetMaterial(materialType);
            }
            catch
            {
                return -1;
            }


            double rezDoubleNotDefect =  GetRezDoubleNotDefec(count, width, length, coefProduct_type);
            double defect =   GetDefec( rezDoubleNotDefect , coefMaterial_type);
            double itogrezDoubl = rezDoubleNotDefect + defect;

            return ItogInt(itogrezDoubl);  
        }

        /// <summary>
        /// округляет  до  целого  в большую  сторону
        /// </summary>
        /// <param name="itogrezDoubl"></param>
        /// <returns></returns>
        public int ItogInt(double itogrezDoubl)
        {
            int x = Convert.ToInt32(itogrezDoubl);

            if ((double)(itogrezDoubl - x) > (double) 0)
            {
                x++;
                return x;
            }
            else
            {
                return x;
            }
        }

        /// <summary>
        /// считает дефект
        /// </summary>
        /// <param name="rezDoubleNotDefect"></param>
        /// <param name="coefMaterial_type"></param>
        /// <returns></returns>
        public double GetDefec(double rezDoubleNotDefect, double coefMaterial_type)
        {   
            var ss = Math.Round(coefMaterial_type, 5);
            var s = rezDoubleNotDefect * ss;
            return s+1;
        }

        /// <summary>
        /// считает  кол-во  материалов без дефекта
        /// </summary>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="coefProduct_type"></param>
        /// <returns></returns>
        public double GetRezDoubleNotDefec(int count, float width, float length, double coefProduct_type)
        {
            return (length * width * coefProduct_type) * count;
        }


        /// <summary>
        /// проверяет входные  параметры
        /// </summary>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns>истина  если  плохие  параметры </returns>
        public bool IsBadArgument(int count, float width, float length)
        {
            if ( count <=0)
            { return true; }

            if ( width<=0)
            {
                return true;
            }

            if (length <= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// поиск коэффициента  брака материала 
        /// </summary>
        /// <param name="material_type"></param>
        /// <returns>получаем  коэффициент брака </returns>
        public float GetMaterial(int material_type)
        {
            switch (material_type)
            {
                case 1: return material_type1; break;
                case 2: return material_type2; break;
                default: throw new ArgumentException("Такого материала  нет"  );
            }
        }

        /// <summary>
        /// поиск продута
        /// </summary>
        /// <param name="productType"></param>
        /// <returns>получаем коэффициент затраты продукта</returns>
        public  double GetProdutc(int productType)
        {
          switch (productType)
            {
                case 1: return product_type1; break;
                case 2: return product_type2; break;
                case 3: return product_type3; break;
                default: throw new ArgumentException("Такого типа нет");
            }
        }
    }
}
