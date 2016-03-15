# Beduini

Članovi tima:
1. Sajra Muratović
2. Mustafa Mahmutović
3. Mirza Ohranović
4. Sanil Musić

### Opis Teme
Sistem za rezervisanje, ocjenjivanje i pretragu lokala, restorana i pub-ova. Korisniku obezbijeđuje zgodan način za organizovanje sastanaka ili izlazaka. Olakšava izbor lokala, a poslodavcu upravljanje rezervacijama.

### Procesi
Korisnik, koji je prijavljen na sistem, ima mogućnost da označi svoje prisustvo na događaju koji je kreirao poslodavac u nekom lokalu. U isto vrijeme, nudi mu se mogućnost rezervacije tako što može pozvati prijatelje na isti događaj, i u zavinosti od odgovorenih poziva kreira se rezervacija za tačan broj osoba. Konačno, nakon što događaj se završi, korisnik može ocijeniti i komentarisati događaj u roku od 24 sata poslije događaja.

### Funkcionalnosti
- registracija poslodavaca i ostalih korisnika
- pretraga lokala
- ocjenivanje i komentarisanje lokala od strane registrovanih korisnika
- kreiranje događaja od strane poslodavaca
- dodavanje slika vezanih za lokale
- kreiranje rezervacija
- lociranje lokala na osnovu prikazane mape

### Akteri
1. **Admin**
Korisnik sa najvišim nivoom privilegija koji vrši provjeru registrovanih korisnika i poslodavaca i održava sistem.
2. **Poslodavac**
Poslodavac je vlasnik lokala ili restorana, koji nakon registracije mora proći posebnu provjeru da mu se omogući upravljanje lokalima i događajima na aplikaciji.
3. **Prijavljeni korisnik**
Korisnik koji je napravio nalog na aplikaciji i ima mogućnost pretrage lokala, kreiranja rezervacija, slanja poziva prijateljima, ocjenjivanja i komentarisanja lokala.
4. **Radnik lokala**
Korisnik kome su naknadno odobrene veće privilegije nad lokalom, poput onih za upravljanje pristiglim rezervacijama.
5. **Gosti stranice**
Korisnici koji koriste aplikaciju ali nisu kreirali nalog. Imaju mogućnost kreiranja naloga i pretrage lokala.
