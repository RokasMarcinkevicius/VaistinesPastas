## Sukurkite WEB aplikaciją su funkcijomis „Importuoti klientus“, „Atnaujinti pašto indeksus“, „Klientų sąrašas“.

# „Importuoti klientus“ - iš duoto JSON failo (klientai.json) reikia į MSSQL duomenų bazę išsaugoti klientų sąrašą (vengti duomenų sudubliavimo).

# „Atnaujinti pašto indeksus“ - iš postit.lt puslapio pagal kliento adresą surasti pašto indeksą ir išsaugoti duomenų bazėje.

Postit.lt užklausos pavyzdys:
https://api.postit.lt/?term=Savanorių+12,+Vilnius&key=postit.lt-examplekey
Naudojimo instrukcija adresu https://postit.lt/API/

# „Klientų sąrašas“ – atidaro langą, kuriame rodome klientų sąrašą (iš duomenų bazės).

- Duomenų bazėje padaryti log lentą, kurioje matytųsi atliktų veiksmų istorija – kada sukurtas kliento įrašas, kada atnaujintas pašto indeksas ir t.t.

- Prisijungimas prie duomenų bazės, postit užklausos adresas, postit key turi būti valdomi per konfigūraciją.

Darbo rezultatas – programos kodo failai ir duomenų bazės struktūros skriptas.
