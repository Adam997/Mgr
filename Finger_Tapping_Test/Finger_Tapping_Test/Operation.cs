using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finger_Tapping_Test
{
    class Operation
    {
        public List<int> DeleteRepeated(List<int> list)
        {
            int i = 0;
            while (i<list.Count-1)
            {
                if (i + 1 < list.Count-1)
                {
                    if (list[i] == list[i + 1])
                    {
                        list.RemoveAt(i);
                    }
                    else i++;
                }
                else break;
            }

            return list;
        }

        public string Validation(List<int> list)
        {
            int j = 0;
            string text = null;
            if (list[j]==0)
            {
                if (list[j+1]==1)
                {
                    if (list[j + 2] == 2)
                    {
                        if (list[j + 3] == 3)
                        {
                            if (list[j +4 ] == 2)
                            {
                                if (list[j + 5] == 1)
                                {
                                    if (list[j + 6] == 0)
                                    {
                                        text = "Poprawne wykonanie badania";
                                    }
                                    else
                                    {
                                        text = "Niepoprawne wykonanie badania";
                                    }
                                }
                                else
                                {
                                    text = "Niepoprawne wykonanie badania";
                                }
                            }
                            else
                            {
                                text = "Niepoprawne wykonanie badania";
                            }
                        }
                        else
                        {
                            text = "Niepoprawne wykonanie badania";
                        }
                    }
                    else
                    {
                        text = "Niepoprawne wykonanie badania";
                    }
                }
                else
                {
                    text = "Niepoprawne wykonanie badania";
                }
            }

            return text;
        }
    }
}
