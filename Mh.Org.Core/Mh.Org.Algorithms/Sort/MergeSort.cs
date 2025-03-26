namespace Mh.Org.Algorithms.Sort
{
    public class MergeSort
    {
        public static T[] Sort<T>(T[] source) 
            where T : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length == 0)
                return [];


            return Sort(source, (0, source.Length - 1));
        }

        

        public static T[] Sort<T>(T[] source, (int min, int max) interval)
            where T : IComparable
        {
            if (Len(interval) == 1)
                return [source[interval.min]];


            var l = Sort(source, GetLeftSubInterval(interval));
            var r = Sort(source, GetRightSubInterval(interval));

            return Merge(l, r);
        }

        public static T[] Merge<T>(T[] l, T[] r)
            where T : IComparable
        {
            var lim = Math.Max(l.Length, r.Length);

            var result = new T[l.Length + r.Length];

            var li = 0;
            var ri = 0;
            var j = 0;

            while(li < l.Length || ri < r.Length)
            {
                if(li >= l.Length)
                {
                    result[j++] = r[ri++];
                    continue;
                }

                if(ri >= r.Length)
                {
                    result[j++] = l[li++];
                    continue;
                }

                if (l[li].CompareTo(r[ri]) < 0)
                {
                    result[j++] = l[li++];
                }
                else
                {
                    result[j++] = r[ri++];
                }
            }


            return result;
        }

        //(0, 1)->(0, 0)
        //(0, 3)->(0, 1)
        //(0, 4)->(0, 1)
        //(2, 4)->(2, 2)
        public static (int min, int max) GetLeftSubInterval((int min, int max) interval)
        {
            var l = Len(interval);
            var max = (int)Math.Floor(l / 2d) - 1;

            return (interval.min, interval.min + max);
        }

        //(0, 1)->(1, 1)
        //(0, 3)->(2, 3)
        //(0, 4)->(2, 4)
        //(2, 4)->(3, 4)
        public static (int min, int max) GetRightSubInterval((int min, int max) interval)
        {
            var l = Len(interval);
            var min = (int)Math.Ceiling(l / 2d) - 1;

            return (interval.max - min, interval.max);
        }

        public static int Len((int min, int max) interval) => interval.max - interval.min + 1;
    }
}
