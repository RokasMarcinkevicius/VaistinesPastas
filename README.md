# VaistinesPastas
# SVARBU! Norint naudoti migracijas naujoje duomenų bazėje pirma užkomentuokite šią funkciją![Svarbu](https://user-images.githubusercontent.com/35724303/168906264-403d7c44-5592-4ba0-a208-289509c0c4bb.jpg)

Pirma pasirinkite "Import Client List"![Swagger](https://user-images.githubusercontent.com/35724303/168906446-b5570664-bfed-4b6e-beb3-45e8979de1f9.jpg)
Jame pasirinkite savo failą: ![Klientai](https://user-images.githubusercontent.com/35724303/168906550-d5bdb4ec-bdbb-4a18-8911-81a44a3eb0b5.jpg)
Visus failo duomenis parodys, bet tik tie kurie yra naujai įterpti turės ID:![IDsjpg](https://user-images.githubusercontent.com/35724303/168906676-dc92247a-187e-4d3e-a846-aabac392e641.jpg)
Po to galite apžiūrėti duomenis:
![ClientList](https://user-images.githubusercontent.com/35724303/168906852-f9ae1f3a-f3d1-41b9-9da4-2f5c72f35964.jpg)
Ar atnaujinti indeksus visiems:
![Indeksai](https://user-images.githubusercontent.com/35724303/168906930-84e4e1d6-5848-4896-b737-85812b0f196a.jpg)
Duomenų bazėje rodo visus sql querių log'us:
![image](https://user-images.githubusercontent.com/35724303/168907183-9d2234c3-296d-4102-8cde-0ca50382a619.png)

Užduoties reikalavimai:
# Done - „Importuoti klientus“ - iš duoto JSON failo (klientai.json) reikia į MSSQL duomenų bazę išsaugoti klientų sąrašą (vengti duomenų sudubliavimo).
# Done - „Atnaujinti pašto indeksus“ - iš postit.lt puslapio pagal kliento adresą surasti pašto indeksą ir išsaugoti duomenų bazėje.
# Done - „Klientų sąrašas“ – atidaro langą, kuriame rodome klientų sąrašą (iš duomenų bazės).
# Done - Duomenų bazėje padaryti log lentą, kurioje matytųsi atliktų veiksmų istorija – kada sukurtas kliento įrašas, kada atnaujintas pašto indeksas ir t.t.
