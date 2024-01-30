using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Item
    {
        public ReactivePropertySlim<int> Number { get; }

        public ReactivePropertySlim<Type1> Type1 { get; }
        public ReadOnlyReactivePropertySlim<string> Type1Disp { get; }

        public ReactivePropertySlim<Type2> Type2 { get; }
        public ReadOnlyReactivePropertySlim<string> Type2Disp { get; }

        public ReactivePropertySlim<string> Name { get; }

        public ReactivePropertySlim<bool> IsCheck { get; }

        public ReactivePropertySlim<string> Text { get; }


        public List<ComboItem<Type1>> Type1Items { get; }
        public List<ComboItem<Type2>> Type2Items { get; }

        public Item(int number, bool isCheck = false)
        {
            Type1Items = new List<ComboItem<Type1>>();
            Type1Items.Add(new(WpfApp1.Type1.Type1_AAAAAAA, "AAAAAAA"));
            Type1Items.Add(new(WpfApp1.Type1.Type1_BBBBB, "BBB"));
            Type1Items.Add(new(WpfApp1.Type1.Type1_CCC, "CCCC"));
            Type1Items.Add(new(WpfApp1.Type1.Type1_DDDD, "DDDDDDD"));

            Type2Items = new List<ComboItem<Type2>>();
            Type2Items.Add(new(WpfApp1.Type2.VVVVVV, "VVVV"));
            Type2Items.Add(new(WpfApp1.Type2.WWWWWWWW, "WWWWWWW"));
            Type2Items.Add(new(WpfApp1.Type2.XXXXX, "X"));
            Type2Items.Add(new(WpfApp1.Type2.YYYY, "YYY"));
            Type2Items.Add(new(WpfApp1.Type2.ZZZZZZZZZ, "ZZZZZZ"));

            Number = new ReactivePropertySlim<int>(number);
            Type1 = new ReactivePropertySlim<Type1>(WpfApp1.Type1.Type1_AAAAAAA);
            Type1Disp = Type1.Select(type => Type1Items.Single(x => x.Value == type).Disp ?? string.Empty).ToReadOnlyReactivePropertySlim<string>();
            Type2 = new ReactivePropertySlim<Type2>(WpfApp1.Type2.VVVVVV);
            Type2Disp = Type2.Select(type => Type2Items.Single(x => x.Value == type).Disp ?? string.Empty).ToReadOnlyReactivePropertySlim<string>();
            Name = new ReactivePropertySlim<string>("Name " + number.ToString());
            IsCheck = new ReactivePropertySlim<bool>(isCheck);
            Text = new ReactivePropertySlim<string>("Text " + number.ToString());
        }
    }

    public class ComboItem<T>(T Value, string Disp)
    {
        public T Value { get; } = Value;
        public string Disp { get; } = Disp;
    }
}
