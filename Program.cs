using CA230310;
using System.Text;

List<Feladvany> feladvanyok = new();
using StreamReader sr = new("..\\..\\..\\src\\szavak.txt", Encoding.Latin1);

while (!sr.EndOfStream) feladvanyok.Add(new Feladvany(sr.ReadLine()));

Console.WriteLine($"2. feladat - szavak száma: {feladvanyok.Count} db");

int lszh = feladvanyok.Max(f => f.Szo.Length);
Console.WriteLine($"3. feladat - leghosszabb szó hossza: {lszh} karakter");

var olhsz = feladvanyok.Where(f => f.Szo.Length == lszh).Select(f => f.Szo);

Console.WriteLine($"4. feladat - legosszabb szó/szavak:");
foreach (var szo in olhsz) Console.WriteLine($"\t{szo}");

Console.WriteLine($"5. feladat - szavak kiírása:");
Tabla tabla = new(feladvanyok);
tabla.Megjelenit();
