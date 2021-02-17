using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Clientes.D1.Dados.Entidades
{
    public class EntidadeBase<U> where U : class
    {
        public int Id { get; set; }

        public T Transform<T>(U obj, Type tipo) where T : class, new()
        {
            T ret = new T();

            foreach (var item in tipo.GetProperties())
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (item.Name == prop.Name)
                    {
                        Type type = ret.GetType();
                        PropertyInfo propertyInfo = type.GetProperty(item.Name);
                        propertyInfo.SetValue(ret, obj.GetType().GetProperty(item.Name).GetValue(obj, null));
                    }
                }
            }

            return ret;
        }

        public List<T> TransformList<T>(IList<U> objs, Type tipo) where T : class, new()
        {
            List<T> dados = new List<T>();

            foreach (var obj in objs)
            {
                dados.Add(Transform<T>(obj, tipo));
            }

            return dados;
        }
    }
}
