using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab8
{
    public interface ICollection<T>
    {
        public void enterData(List<T> list);
        public void addData(T element);
        public void printData();
        public void deleteData(T element);
    }

    public class CollectionType<T> : ICollection<T>
    {
        public List<T> list { get; set; }
        public CollectionType()
        {
            list = new List<T>();
        }
        public void enterData(List<T> list)
        {
            this.list = list;
        }
        public void addData(T element)
        {
            list.Add(element);
        }
        public void printData()
        {
            foreach (T element in this.list)
            {
                Console.Write(element + "\t");
            }
            Console.WriteLine("\n");
        }
        public void deleteData(T deleteEl)
        {
            list.Remove(deleteEl);
        }




        // ===============================  ПЕРЕГРУЗКИ  ===============================

        public static CollectionType<T> operator *(CollectionType<T> t1, CollectionType<T> t2)
        {
            CollectionType<T> tOut = new CollectionType<T>();
            
            if (t1.list is List<int>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    tOut.list.Add((T)(object)((int)(object)t1.list[i] * (int)(object)t2.list[i]));
                }
            }

            if (t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    tOut.list.Add((T)(object)((double)(object)t1.list[i] * (double)(object)t2.list[i]));
                }
            }

            if (t1.list is List<string>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    tOut.list.Add((T)(object)((string)(object)t1.list[i] + (string)(object)t2.list[i]));
                }
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = t2.list as List<Car>;
                List<Car> carListOut = new List<Car>();

                for (int i = 0; i < t1.list.Count; i++)
                {
                    carListOut.Add(carList1[i]);
                }
                for (int i = 0; i < carListOut.Count; i++)
                {
                    carListOut[i].Power = carList1[i].Power * carList2[i].Power;
                    Console.WriteLine(carListOut[i].ToString());
                }
            }

            return tOut;
        }


        public static bool operator >(CollectionType<T> t1, CollectionType<T> t2)
        {
            if (t1.list is List<int>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((int)(object)t2.list[i] > (int)(object)t1.list[i])
                        return false;
                }
                return true;
            }

            if (t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((double)(object)t2.list[i] > (double)(object)t1.list[i])
                        return false;
                }
                return true;
            }

            if (t1.list is List<string>)
            {
                List<string> outList1 = new List<string>();
                outList1 = t1.list as List<string>;
                List<string> outList2 = new List<string>();
                outList2 = t2.list as List<string>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (outList1[i].Length < outList2[i].Length)
                        return false;
                }
                return true;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = t2.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power < carList2[i].Power)
                        return false;
                }

                return true;
            }

            return false;
        }


        public static bool operator <(CollectionType<T> t1, CollectionType<T> t2)
        {
            if (t1.list is List<int>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((int)(object)t2.list[i] < (int)(object)t1.list[i])
                        return false;
                }
                return true;
            }

            if (t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((double)(object)t2.list[i] < (double)(object)t1.list[i])
                        return false;
                }
                return true;
            }

            if (t1.list is List<string>)
            {
                List<string> outList1 = new List<string>();
                outList1 = t1.list as List<string>;
                List<string> outList2 = new List<string>();
                outList2 = t2.list as List<string>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (outList1[i].Length > outList2[i].Length)
                        return false;
                }

                return true;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = t2.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power > carList2[i].Power)
                        return false;
                }

                return true;
            }

            return false;
        }


        public static bool operator true(CollectionType<T> t1)
        {
            if (t1.list is List<int> || t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((int)(object)t1.list[i] < 0)
                        return false;
                }
                return true;
            }

            if (t1.list is List<string>)
            {
                List<string> outList = new List<string>();
                outList = t1.list as List<string>;
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (outList[i].Length < 2)
                        return false;
                }
                return true;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power < 500)
                        return false;
                }

                return true;
            }

            return false;
        }


        public static bool operator false(CollectionType<T> t1)
        {
            if (t1.list is List<int> || t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if ((int)(object)t1.list[i] > 0)
                        return false;
                }
                return true;
            }

            if (t1.list is List<string>)
            {
                List<string> outList = new List<string>();
                outList = t1.list as List<string>;
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (outList[i].Length > 2)
                        return false;
                }
                return true;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power > 500)
                        return false;
                }

                return true;
            }

            return false;
        }


        public static bool operator ==(CollectionType<T> t1, CollectionType<T> t2)
        { 
            if (t1.list is List<int> || t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (!t1.list[i].Equals(t2.list[i]))
                        return false;
                }
                return true;
            }

            if (t1.list is List<string>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (!t1.list[i].Equals(t2.list[i]))
                        return false;
                }
                return true;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = t2.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power != carList2[i].Power)
                        return false;
                }

                return true;
            }

            return false;
        }


        public static bool operator !=(CollectionType<T> t1, CollectionType<T> t2)
        {
            if (t1.list is List<int> || t1.list is List<double>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (!t1.list[i].Equals(t2.list[i]))
                        return true;
                }
                return false;
            }

            if (t1.list is List<string>)
            {
                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (!t1.list[i].Equals(t2.list[i]))
                        return true;
                }
                return false;
            }

            if (t1.list is List<Car>)
            {
                List<Car> carList1 = new List<Car>();
                carList1 = t1.list as List<Car>;
                List<Car> carList2 = new List<Car>();
                carList2 = t2.list as List<Car>;

                for (int i = 0; i < t1.list.Count; i++)
                {
                    if (carList1[i].Power == carList2[i].Power)
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}