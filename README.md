
# Advent of Code Solutions

Bienvenue sur mon repository contenant mes solutions pour l'Advent of Code ! 🎄

## Table des Matières

- [Aperçu](#aperçu)
- [Structure du Repository](#structure-du-repository)
- [Technologies Utilisées](#technologies-utilisées)
- [Comment Exécuter les Solutions](#comment-exécuter-les-solutions)
- [Contributions](#contributions)
- [Licence](#licence)

## Aperçu

Ce repository contient mes solutions pour les défis quotidiens de l'Advent of Code, un événement annuel de programmation où chaque jour de décembre jusqu'à Noël, un nouveau défi est publié. Vous pouvez en savoir plus sur [adventofcode.com](https://adventofcode.com).

## Structure du Repository

Chaque jour de l'Advent of Code a son propre dossier contenant les fichiers de solution. La structure du repository est la suivante :

```
advent-of-code/
│
├── year/
│   ├── day01/
│   │   ├── input.txt
│   │   └── solution.js
│   ├── day02/
│   │   ├── input.txt
│   │   └── solution.js
│   └── ...
└── README.md
```

- `year/dayXX/` : Dossier pour chaque jour (et chaque année si nécessaire)
  - `input.txt` : Le fichier d'entrée pour le défi du jour.
  - `solution.js` : Mon script de solution pour le défi du jour.

## Technologies Utilisées

Les solutions sont principalement écrites en **Node.js**.

## Comment Exécuter les Solutions

1. Clonez ce repository :
   ```bash
   git clone https://github.com/ton-username/advent-of-code.git
   cd advent-of-code
   ```

2. Naviguez vers le dossier du jour que vous souhaitez exécuter :
   ```bash
   cd year/dayXX
   ```

3. Installez les dépendances (si nécessaire) :
   ```bash
   npm install
   ```

4. Exécutez le script de solution :
   ```bash
   node solution.js
   ```

Assurez-vous d'avoir Node.js installé sur votre machine. Les solutions peuvent aussi nécessiter des bibliothèques spécifiques, qui seront mentionnées dans le code ou un fichier `package.json` si nécessaire.

## Contributions

Les contributions sont les bienvenues ! Si vous avez une meilleure solution ou une optimisation, n'hésitez pas à ouvrir une pull request. Veuillez suivre ces étapes :

1. Fork le repository
2. Créez une branche pour votre modification (`git checkout -b amélioration/ma-contribution`)
3. Commitez vos modifications (`git commit -m 'Ajouter une explication de la contribution'`)
4. Poussez vers la branche (`git push origin amélioration/ma-contribution`)
5. Ouvrez une Pull Request

## Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

---

J'espère que ce README répondra à tes attentes et qu'il sera utile pour organiser et présenter tes solutions de l'Advent of Code !
