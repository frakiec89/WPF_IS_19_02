﻿using System;
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
        private const double material_type1 = 0.3; // коэффициенты брака
        private const double material_type2 = 0.12;

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


            double rezDoubleNotDefect = GetRezDoubleNotDefec(count, width, length, coefProduct_type);
            double defect = GetDefec( rezDoubleNotDefect , coefMaterial_type);
            double itogrezDoubl = rezDoubleNotDefect + defect;

            return ItogInt(itogrezDoubl);  
        }

        /// <summary>
        /// округляет  до  целого  в большую  сторону
        /// </summary>
        /// <param name="itogrezDoubl"></param>
        /// <returns></returns>
        private int ItogInt(double itogrezDoubl)
        {
            int x = Convert.ToInt32(itogrezDoubl);

            if ( (double)(itogrezDoubl - x)> 0)
            {
                return x++;
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
        private double GetDefec(double rezDoubleNotDefect, double coefMaterial_type)
        {
            return rezDoubleNotDefect * coefMaterial_type;
        }

        /// <summary>
        /// считает  кол-во  материалов без дефекта
        /// </summary>
        /// <param name="count"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="coefProduct_type"></param>
        /// <returns></returns>
        private double GetRezDoubleNotDefec(int count, float width, float length, double coefProduct_type)
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
        private bool IsBadArgument(int count, float width, float length)
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
        public double GetMaterial(int material_type)
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
        public double GetProdutc(int productType)
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
