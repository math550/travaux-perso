-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Ven 26 Mai 2017 à 00:54
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `leagueoflegends`
--

-- --------------------------------------------------------

--
-- Structure de la table `champion`
--

CREATE TABLE `champion` (
  `id_champion` int(11) NOT NULL,
  `langue` varchar(255) DEFAULT 'FR',
  `nom` text,
  `titre` varchar(255) DEFAULT NULL,
  `vie` int(11) DEFAULT NULL,
  `mana` int(11) DEFAULT NULL,
  `energie` int(11) DEFAULT NULL,
  `attack_damage` int(11) DEFAULT NULL,
  `ability_power` int(11) DEFAULT NULL,
  `armure` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `champion`
--

INSERT INTO `champion` (`id_champion`, `langue`, `nom`, `titre`, `vie`, `mana`, `energie`, `attack_damage`, `ability_power`, `armure`) VALUES
(1, 'FR', 'Nami', 'Aquamancienne', 489, 300, 0, 51, 65, 20),
(2, 'FR', 'Annie', 'Enfant des ténèbres', 512, 500, 0, 50, 75, 19),
(3, 'FR', 'Zed', 'Maître des ombres', 579, 0, 200, 55, 0, 27),
(4, 'FR', 'Nautilus', 'Titan des profondeurs', 576, 250, 0, 58, 20, 26),
(5, 'FR', 'Leona', 'Aube radieuse', 576, 250, 0, 60, 25, 27),
(6, 'FR', 'Gnar', 'Chaînon manquant', 540, 0, 0, 51, 15, 23),
(7, 'FR', 'Kindred', 'Chasseurs éternels', 540, 200, 0, 54, 15, 20),
(8, 'FR', 'Shyvana', 'Demi-dragon', 595, 0, 0, 61, 25, 28),
(9, 'FR', 'Vayne', 'Chasseur nocturne', 498, 225, 0, 56, 10, 19),
(10, 'FR', 'Akali', 'Poing des ombres', 588, 0, 200, 58, 20, 26),
(11, 'FR', 'Teemo', 'Scout de Bantam', 516, 150, 0, 50, 30, 24),
(1, 'EN', 'Nami', 'the Tidecaller', 489, 300, 0, 51, 65, 20),
(2, 'EN', 'Annie', 'the Dark Child', 512, 500, 0, 50, 75, 19),
(3, 'EN', 'Zed', 'the Master of Shadows', 579, 0, 200, 55, 0, 27),
(4, 'EN', 'Nautilus', 'the Titan of the Depths', 576, 250, 0, 58, 20, 26),
(5, 'EN', 'Leona', 'the Radiant Dawn', 576, 250, 0, 60, 25, 27),
(6, 'EN', 'Gnar', 'the Missing Link', 540, 0, 0, 51, 15, 23),
(7, 'EN', 'Kindred', 'The Eternal Hunters', 540, 200, 0, 54, 15, 20),
(8, 'EN', 'Shyvana', 'the Half-Dragon', 595, 0, 0, 61, 25, 28),
(9, 'EN', 'Vayne', 'the Night Hunter', 498, 225, 0, 56, 10, 19),
(10, 'EN', 'Akali', 'the Fist of Shadow', 588, 0, 200, 58, 20, 26),
(11, 'EN', 'Teemo', 'the Swift Scout', 516, 150, 0, 50, 30, 24);

-- --------------------------------------------------------

--
-- Structure de la table `click`
--

CREATE TABLE `click` (
  `id_click` int(11) NOT NULL,
  `nombre_click` int(11) DEFAULT NULL,
  `date_click` date DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `click`
--

INSERT INTO `click` (`id_click`, `nombre_click`, `date_click`) VALUES
(5, 24, '2017-05-21'),
(6, 63, '2017-05-24'),
(7, 276, '2017-05-25');

-- --------------------------------------------------------

--
-- Structure de la table `commentaire_champion`
--

CREATE TABLE `commentaire_champion` (
  `id_commentaire_champion` int(11) NOT NULL,
  `id_champion` int(11) DEFAULT NULL,
  `commentaire` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `commentaire_champion`
--

INSERT INTO `commentaire_champion` (`id_commentaire_champion`, `id_champion`, `commentaire`) VALUES
(1, 1, 'allo\r\n'),
(2, 2, 'ANNIE!!!!'),
(3, 2, 'elle est la meilleur');

-- --------------------------------------------------------

--
-- Structure de la table `connectes`
--

CREATE TABLE `connectes` (
  `ip` varchar(15) NOT NULL,
  `timestamp` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `connectes`
--

INSERT INTO `connectes` (`ip`, `timestamp`) VALUES
('::1', 1495681753);

-- --------------------------------------------------------

--
-- Structure de la table `descriptionitem`
--

CREATE TABLE `descriptionitem` (
  `id_description_item` int(11) NOT NULL,
  `id_item` int(11) NOT NULL,
  `unique_passif` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `descriptionitem`
--

INSERT INTO `descriptionitem` (`id_description_item`, `id_item`, `unique_passif`) VALUES
(1, 1, 'Increases Ability Power by 30%.'),
(2, 2, '+10% Cooldown Reduction'),
(3, 3, '+35% Magic Penetration.'),
(4, 4, '+500000000 Movement Speed out of Combat'),
(5, 5, NULL),
(6, 6, 'Dealing physical damage to an enemy champion Cleaves them, reducing their Armor by 5% for 6 seconds (stacks up to 6 times, up to 30%).'),
(7, 7, 'Increases all healing received by 25%.'),
(8, 4, '+20 Movement Speed out of Combat'),
(10, 22, 'sdgargwregwersg'),
(11, 22, 'oiuybyuv');

-- --------------------------------------------------------

--
-- Structure de la table `etoile`
--

CREATE TABLE `etoile` (
  `id` int(11) NOT NULL,
  `id_item` int(11) DEFAULT NULL,
  `rate` int(11) DEFAULT NULL,
  `user_id` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `etoile`
--

INSERT INTO `etoile` (`id`, `id_item`, `rate`, `user_id`) VALUES
(4, NULL, 2, '837ec5754f503cfaaee0929fd48974e7');

-- --------------------------------------------------------

--
-- Structure de la table `habilete_champion`
--

CREATE TABLE `habilete_champion` (
  `id_habilete_champion` int(11) NOT NULL,
  `id_champion` int(11) NOT NULL,
  `habilete` text,
  `nom` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `habilete_champion`
--

INSERT INTO `habilete_champion` (`id_habilete_champion`, `id_champion`, `habilete`, `nom`) VALUES
(1, 2, 'After casting 4 spells, Annie\'s next offensive spell will stun the target for a short duration.', 'Pyromania'),
(2, 1, 'When Nami abilities hit allied champions they gain Movement Speed for a short duration.', 'Surging Tides'),
(3, 4, 'Nautilus basic attacks deal bonus physical damage and immobilize his targets. This effect cannot happen more than once every few seconds on the same target.', 'Staggering Blow'),
(4, 3, 'Zed basic attacks against targets below 50% Health deal 6-10% of the target maximum Health as bonus Magic Damage. This effect can only occur once every 10 seconds on the same target.', 'Contempt for the Weak'),
(5, 5, 'Damaging spells afflict enemies with Sunlight for 3.5 seconds. When allied Champions deal damage to those targets, they consume the Sunlight to deal additional magic damage.', 'Sunlight'),
(6, 6, 'While in combat Gnar generates Rage. At maximum Rage his next ability will transform him into Mega Gnar, granting increased survivability and access to new spells.', 'Rage Gene'),
(7, 7, 'Kindred can mark targets to Hunt. Successfully completing a Hunt permanently empowers Kindred basic attacks and Dance of Arrows.', 'Mark of the Kindred'),
(8, 8, 'Shyvana deals bonus damage to dragons and gains Armor and Magic Resistance. As Shyvana and her allies slay more dragons, she gains more bonus Armor and Magic Resistance.', 'Fury of the Dragonborn'),
(9, 9, 'Vayne ruthlessly hunts evil-doers. She gains 30 Movement Speed when moving toward nearby enemy champions.', 'Night Hunter'),
(10, 10, 'Akali first two attacks are empowered. The first strike heals her, and the second strike deals bonus magic damage. Twin Disciplines will recharge itself automatically a short while after being used.', 'Twin Disciplines'),
(11, 11, 'If Teemo stands still and takes no actions for a short duration, he becomes Invisible indefinitely. If he in brush, Teemo can enter and maintain his Invisibility while moving. After leaving Invisibility, Teemo gains the Element of Surprise, increasing his Attack Speed for 3 seconds.', 'Guerrilla Warfare'),
(12, 2, 'Cost: 70/80/90/100/110 Mana \r\nRange: 600\r\nAnnie casts a blazing cone of fire, dealing damage to all enemies in the area.\r\nCasts a cone of fire dealing 70/115/160/205/250 (+85% Ability Power) magic damage to all enemies in the area.', 'Incinerate'),
(13, 2, 'Cost: 20 Mana \r\nRange: 0\r\nGrants Annie and Tibbers increased percentage Damage Resist and damages enemies who attack with basic attacks.\r\nAnnie grants herself and Tibbers 16/22/28/34/40% damage reduction for 3 seconds.While the shield is active, enemies who basic attack it take 20/30/40/50/60 (+20% Ability Power) magic damage.', 'Molten Shield'),
(14, 2, 'Cost: 100 Mana \r\nRange: 600\r\nAnnie wills her bear Tibbers to life, dealing damage to units in the area. Tibbers can attack and also burns enemies that stand near him.\r\nSummons Tibbers, dealing 150/275/400 (+65% Ability Power) magic damage to enemies in the target area. For the next 45 seconds, Tibbers burns nearby enemies for 10/15/20 (+10% Ability Power) per second and attacks for 50/75/100 (+0) as magic damage. Annie can control Tibbers by reactivating this ability.\r\nTibbers Enrages when: summoned; Annie uses Pyromania on an enemy Champion; and when Annie dies.\r\nEnrages: Tibbers gains 275% Attack Speed and 100% Movement Speed, decaying over 3 seconds.', 'Summon: Tibbers');

-- --------------------------------------------------------

--
-- Structure de la table `item`
--

CREATE TABLE `item` (
  `id_item` int(11) NOT NULL,
  `nom` text,
  `langue` varchar(10) DEFAULT NULL,
  `bonus_ap` int(11) DEFAULT NULL,
  `bonus_ad` int(11) DEFAULT NULL,
  `bonus_armure` int(11) DEFAULT NULL,
  `bonus_cooldown` int(11) DEFAULT NULL,
  `bonus_hp` int(11) DEFAULT NULL,
  `prix` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Contenu de la table `item`
--

INSERT INTO `item` (`id_item`, `nom`, `langue`, `bonus_ap`, `bonus_ad`, `bonus_armure`, `bonus_cooldown`, `bonus_hp`, `prix`) VALUES
(1, 'Rabadon\'s deathcap', 'FR', 120, 0, 0, 0, 0, 3800),
(2, 'Warmog\'s Armor', 'FR', 800, 0, 0, 0, 0, 2850),
(3, 'Void Staff', 'FR', 80, 0, 0, 0, 0, 2650),
(4, 'Youmuu\'s Ghostblade', 'FR', 0, 60, 0, 10, 0, 2900),
(5, 'Zhonya\'s Hourglass', 'FR', 70, 0, 45, 10, 0, 2900),
(6, 'The Black Cleaver', 'FR', 0, 50, 0, 20, 300, 3100),
(7, 'Spirit Visage', 'FR', 0, 0, 0, 10, 500, 2800),
(1, 'Rabadon\'s deathcap', 'EN', 120, 0, 0, 0, 0, 3800),
(2, 'Warmog\'s Armor', 'EN', 800, 0, 0, 0, 0, 2850),
(3, 'Void Staff', 'EN', 80, 0, 0, 0, 0, 2650),
(4, 'Youmuu\'s Ghostblade', 'EN', 0, 60, 0, 10, 0, 2900),
(5, 'Zhonya\'s Hourglass', 'EN', 70, 0, 45, 10, 0, 2900),
(6, 'The Black Cleaver', 'EN', 0, 50, 0, 20, 300, 3100),
(7, 'Spirit Visage', 'EN', 0, 0, 0, 10, 500, 2800);

-- --------------------------------------------------------

--
-- Structure de la table `membre`
--

CREATE TABLE `membre` (
  `id_membre` int(11) NOT NULL,
  `pseudonyme` varchar(255) NOT NULL,
  `motdepasse` varchar(255) NOT NULL,
  `courriel` varchar(255) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `genre` varchar(10) NOT NULL,
  `position` varchar(15) NOT NULL,
  `role` enum('membre','administrateur') NOT NULL DEFAULT 'membre'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `membre`
--

INSERT INTO `membre` (`id_membre`, `pseudonyme`, `motdepasse`, `courriel`, `nom`, `genre`, `position`, `role`) VALUES
(2, 'pasadmin', 'ae4e268a31b839566f62b259fb3fd9bc', '', '', '', '', 'membre'),
(3, 'allo', 'allo', 'allo', 'allo', '', '', 'administrateur'),
(12, 'nadine', 'nadine', '', 'nadine', '', '', 'administrateur'),
(15, '', '', '', '', '', '', 'membre');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `champion`
--
ALTER TABLE `champion`
  ADD UNIQUE KEY `id_champion_langue` (`id_champion`,`langue`);

--
-- Index pour la table `click`
--
ALTER TABLE `click`
  ADD PRIMARY KEY (`id_click`);

--
-- Index pour la table `commentaire_champion`
--
ALTER TABLE `commentaire_champion`
  ADD PRIMARY KEY (`id_commentaire_champion`);

--
-- Index pour la table `descriptionitem`
--
ALTER TABLE `descriptionitem`
  ADD PRIMARY KEY (`id_description_item`);

--
-- Index pour la table `habilete_champion`
--
ALTER TABLE `habilete_champion`
  ADD PRIMARY KEY (`id_habilete_champion`);

--
-- Index pour la table `membre`
--
ALTER TABLE `membre`
  ADD PRIMARY KEY (`id_membre`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `champion`
--
ALTER TABLE `champion`
  MODIFY `id_champion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;
--
-- AUTO_INCREMENT pour la table `click`
--
ALTER TABLE `click`
  MODIFY `id_click` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT pour la table `commentaire_champion`
--
ALTER TABLE `commentaire_champion`
  MODIFY `id_commentaire_champion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=151;
--
-- AUTO_INCREMENT pour la table `descriptionitem`
--
ALTER TABLE `descriptionitem`
  MODIFY `id_description_item` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT pour la table `habilete_champion`
--
ALTER TABLE `habilete_champion`
  MODIFY `id_habilete_champion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT pour la table `membre`
--
ALTER TABLE `membre`
  MODIFY `id_membre` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
