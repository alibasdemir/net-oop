namespace examples._05_GenericType

// Generic type, C# ve benzeri programlama dillerinde, bir veri yapısının veya bir sınıfın türünün (type) belirsiz olduğu durumları temsil eden bir yapıdır. Bu, bir sınıfın veya metodu, belirli bir tür yerine genel olarak bir türle çalışacak şekilde tasarlamak için kullanılır. Genel olarak, aynı kod parçalarını farklı türlerle çalışacak şekilde esnek hale getirmek için kullanılır.

// Generic type'lar, tip güvenliği sağlar ve kod tekrarını azaltır. Ayrıca, türler arası dönüşümleri azaltarak kodun daha okunabilir ve bakımı daha kolay hale getirir.

{
    public class Kutu<T>
    {
        private T _icerik; // T türünde bir özel alan

        public Kutu(T icerik)      // Kurucu metod: Kutu sınıfı oluşturulurken içeriğini belirlemek için kullanılır
        {
            _icerik = icerik;
        }


        public T Icerik             // Icerik özelliği: Kutu içeriğine erişmek için kullanılır
        {
            get { return _icerik; }
            set { _icerik = value; }
        }

    }
}
