using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemMonitorowaniaWydatkowDomowych.Data;
using SystemMonitorowaniaWydatkowDomowych.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace SystemMonitorowaniaWydatkowDomowych.Controllers
{ 
    public class WydatkiController : Controller  
    { 
        private readonly KontekstBazyDanych _kontekst;

        public WydatkiController(KontekstBazyDanych kontekst) 
        {
            _kontekst = kontekst;
        }

        public async Task<IActionResult> Index(
            int? kategoriaId,
            string? szukaj,
            string? sortowanie)

        {
            var wydatkiQuery = _kontekst.Wydatki
                .Include(w => w.Kategoria)
                .Include(w => w.MetodaPlatnosci)
                .AsQueryable();

            if (kategoriaId.HasValue)
            {
                wydatkiQuery = wydatkiQuery.Where(w => w.KategoriaId == kategoriaId.Value);
            }

            if (!string.IsNullOrWhiteSpace(szukaj))
            {
                wydatkiQuery = wydatkiQuery.Where(w => w.Opis.Contains(szukaj));
            }

            if (sortowanie == "kwota_rosnaco")
            {
                wydatkiQuery = wydatkiQuery.OrderBy(w => w.Kwota);
            }
            else if (sortowanie == "kwota_malejaco")
            {
                wydatkiQuery = wydatkiQuery.OrderByDescending(w => w.Kwota);
            }


            var wydatki = await wydatkiQuery.ToListAsync();


            ViewBag.SumaWydatkow = wydatki.Sum(w => w.Kwota);
            ViewBag.Kategorie = new SelectList(_kontekst.Kategorie, "Id", "Nazwa", kategoriaId);
            ViewBag.Szukaj = szukaj;
            ViewBag.Sortowanie = sortowanie;

            ViewBag.PodsumowanieKategorii = wydatki
            .GroupBy(w => w.Kategoria.Nazwa)
            .Select(g => new
            {
                Kategoria = g.Key,
                Suma = g.Sum(w => w.Kwota)
            })
            .ToList();

            return View(wydatki);
        }
        
        public IActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(_kontekst.Kategorie, "Id", "Nazwa");
            ViewBag.MetodaPlatnosciId = new SelectList(_kontekst.MetodyPlatnosci, "Id", "Nazwa");

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var wydatek = await _kontekst.Wydatki.FindAsync(id);

            if (wydatek == null)
            {
                return NotFound();
            }

            return View(wydatek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Wydatek wydatek)
        {
            if (id != wydatek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _kontekst.Update(wydatek);
                await _kontekst.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(wydatek);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Wydatek wydatek)
        {
            if (ModelState.IsValid)
            {
                _kontekst.Add(wydatek);
                await _kontekst.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.KategoriaId = new SelectList(_kontekst.Kategorie, "Id", "Nazwa", wydatek.KategoriaId);
            ViewBag.MetodaPlatnosciId = new SelectList(_kontekst.MetodyPlatnosci, "Id", "Nazwa", wydatek.MetodaPlatnosciId);

            return View(wydatek);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var wydatek = await _kontekst.Wydatki
                .Include(w => w.Kategoria)
                .Include(w => w.MetodaPlatnosci)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (wydatek == null)
            {
                return NotFound();
            }

            return View(wydatek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wydatek = await _kontekst.Wydatki.FindAsync(id);

            if (wydatek != null)
            {
                _kontekst.Wydatki.Remove(wydatek);
                await _kontekst.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> DodajDaneTestowe()
        {
            if (!_kontekst.Kategorie.Any())
            {
                _kontekst.Kategorie.AddRange(
                    new Kategoria { Nazwa = "Jedzenie" },
                    new Kategoria { Nazwa = "Transport" },
                    new Kategoria { Nazwa = "Rachunki" }
                );
            }

            if (!_kontekst.MetodyPlatnosci.Any())
            {
                _kontekst.MetodyPlatnosci.AddRange(
                    new MetodaPlatnosci { Nazwa = "Gotówka" },
                    new MetodaPlatnosci { Nazwa = "Karta" },
                    new MetodaPlatnosci { Nazwa = "BLIK" }
                );
            }

            await _kontekst.SaveChangesAsync();

            if (!_kontekst.Wydatki.Any())
            {
                var kategoria = _kontekst.Kategorie.First();
                var metoda = _kontekst.MetodyPlatnosci.First();

                _kontekst.Wydatki.Add(
                    new Wydatek
                    {
                        Opis = "Zakupy spożywcze",
                        Kwota = 50,
                        Data = DateTime.Now,
                        KategoriaId = kategoria.Id,
                        MetodaPlatnosciId = metoda.Id
                    }
                );

                await _kontekst.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }

}  




