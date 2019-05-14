/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50624
 Source Host           : localhost:3306
 Source Schema         : sp

 Target Server Type    : MySQL
 Target Server Version : 50624
 File Encoding         : 65001

 Date: 14/05/2019 18:35:17
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for bahar
-- ----------------------------
DROP TABLE IF EXISTS `bahar`;
CREATE TABLE `bahar`  (
  `SiraNo` int(11) NOT NULL AUTO_INCREMENT,
  `Prg_Ad` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Prg_Kod` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ogr_Sekli` varchar(5) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `donem` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Ders_Kodu` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Ders_Adi` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ogr_Sayisi` int(11) NULL DEFAULT NULL,
  `Unvan` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ad_Soyad` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Tarih` date NULL DEFAULT NULL,
  `Saat` time(0) NULL DEFAULT NULL,
  `Derslik1` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik2` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik3` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik4` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Y_Ogr_Sayisi` int(11) NULL DEFAULT NULL,
  `Gozetmen1` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Gozetmen2` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Gozetmen3` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  PRIMARY KEY (`SiraNo`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 63 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of bahar
-- ----------------------------
INSERT INTO `bahar` VALUES (61, 'Bilgisayar Programcılığı', 'BP101', 'IO', '4. Dönem', 'ING88', 'İngilizce II5', 55, 'Doc. Dr. ', 'Ahmet Kaya', '2019-02-08', '10:00:00', 'a34', NULL, NULL, NULL, 55, 'asd ömer', 'asdasd ömer', 'Doc. Kenan İmirzalıoğlu');
INSERT INTO `bahar` VALUES (62, 'Tarım ve Köyişleri', 'TRM101', 'G', '4. Dönem', 'ING88', 'İngilizce II5', 111, 'asdasd', 'ömer', '2019-02-08', '10:00:00', 'a54', 'a25', 'a34', 'a41', 111, 'Doc. Kenan İmirzalıoğlu', 'asdasd ömer', NULL);

-- ----------------------------
-- Table structure for bolumler
-- ----------------------------
DROP TABLE IF EXISTS `bolumler`;
CREATE TABLE `bolumler`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `program_adi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `bolum_adi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `program_kodu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of bolumler
-- ----------------------------
INSERT INTO `bolumler` VALUES (11, 'Bilgisayar Programcılığı', 'Bilişim Bölümü', 'BPP3');
INSERT INTO `bolumler` VALUES (13, 'Tarım ve Köyişleri', 'Ziraat Bölümü', 'TRM101');
INSERT INTO `bolumler` VALUES (14, 'Elektrik', 'Elektrik Elektronik', 'ELK3');

-- ----------------------------
-- Table structure for ders
-- ----------------------------
DROP TABLE IF EXISTS `ders`;
CREATE TABLE `ders`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ders_adi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ders_kodu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `donem` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `bolum` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 30 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of ders
-- ----------------------------
INSERT INTO `ders` VALUES (28, 'İngilizce II5', 'ING88', '4. Dönem', 'ORTAK DERS');
INSERT INTO `ders` VALUES (29, 'Matematik', 'MTM10', '1. Dönem', 'ORTAK DERS');

-- ----------------------------
-- Table structure for guz
-- ----------------------------
DROP TABLE IF EXISTS `guz`;
CREATE TABLE `guz`  (
  `SiraNo` int(11) NOT NULL AUTO_INCREMENT,
  `Prg_Ad` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Prg_Kod` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ogr_Sekli` varchar(5) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `donem` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ders_Kodu` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Ders_Adi` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ogr_Sayisi` int(11) NULL DEFAULT NULL,
  `Unvan` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Ad_Soyad` varchar(100) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Tarih` date NULL DEFAULT NULL,
  `Saat` time(0) NULL DEFAULT NULL,
  `Derslik1` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik2` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik3` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Derslik4` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Y_Ogr_Sayisi` int(11) NULL DEFAULT NULL,
  `Gozetmen1` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Gozetmen2` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  `Gozetmen3` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NULL DEFAULT NULL,
  PRIMARY KEY (`SiraNo`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 441 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of guz
-- ----------------------------
INSERT INTO `guz` VALUES (1, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'MTE002', 'Matematik', 45, 'Öğr.Gör.', 'Mustafa TEMEL', '2019-02-14', '14:00:00', 'B46', 'a34', 'a54', NULL, 45, 'Yasemin ÇİFTÇİ ŞENER', 'Duygu HÜYÜK', NULL);
INSERT INTO `guz` VALUES (2, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'BPP101', 'Programlama Temelleri', 105, 'Doc. Dr. ', 'Ahmet Kaya', '2017-12-28', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Öğr.Gör. Mustafa TEMEL', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (3, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP102', 'Grafik ve Animasyon', 58, 'Öğr.Gör.', 'Ersoy MEVSİM', '2017-12-29', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Mehmet Ali ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (4, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'BPP103', 'WEB Tasarımının  Temelleri', 89, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '13:00:00', 'A32', NULL, NULL, NULL, 0, 'Hakan MUTLU', 'Tekin ÖZTÜRK', NULL);
INSERT INTO `guz` VALUES (5, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 105, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'B46', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (6, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 104, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B18', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (7, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 113, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '12:30:00', 'B46', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (8, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'BPP104', 'Yazılım Kurulumu ve Yönetimi', 62, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-02', '13:00:00', 'A32', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (9, 'Bilgisayar Programcılığı', 'BPP1', 'G', NULL, 'BPP105', 'Ofis Yazılımları', 62, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '13:00:00', 'A32', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (10, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP301', 'İnternet Proğramcılığı I', 66, 'Öğr.Gör.', 'Ersoy MEVSİM', '2019-04-08', '19:00:00', 'a34', 'a54', NULL, NULL, 66, 'Şennur ASMA DELEN', 'Ersoy MEVSİM', NULL);
INSERT INTO `guz` VALUES (11, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP302', 'Nesne Tabanlı Programlama I', 76, 'Öğr.Gör.', 'Ersoy MEVSİM', '2019-04-08', '10:00:00', 'A32', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', 'Arzu GÖNÜLOL', NULL);
INSERT INTO `guz` VALUES (12, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP303', 'Açık Kaynak İşletim Sistemi', 64, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2017-12-26', '09:00:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KAHYA', 'Hakan MUTLU', NULL);
INSERT INTO `guz` VALUES (13, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP304', 'Ağ Temelleri', 59, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2017-12-27', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (14, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP305', 'Görsel Programlama I', 62, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (15, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'KGS005', 'Kalite Güvence ve Standartları', 56, 'Öğr.Gör.Dr.', 'Emre TAHTABİÇEN', '2017-12-29', '09:00:00', 'B47', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (16, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'ÖMİ101', 'Mesleki Yabancı Dil I', 52, 'Okt.', 'Aysun ERTEKİN', '2017-12-28', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (17, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'MTE002', 'Matemati', 87, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-25', '18:30:00', 'B46', NULL, NULL, NULL, 0, 'Mustafa TEMEL', NULL, NULL);
INSERT INTO `guz` VALUES (18, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP101', 'Programlama Temeller', 97, 'Öğr.Gör.', 'Ersoy MEVSİM', '2017-12-28', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', 'Huzur DEVECİ', NULL);
INSERT INTO `guz` VALUES (19, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP102', 'Grafik ve Animasyon', 47, 'Öğr.Gör.', 'Ersoy MEVSİM', '2017-12-29', '17:00:00', 'A23', NULL, NULL, NULL, 0, 'Mehmet Ali ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (20, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP103', 'WEB Tasarımının  Temelleri', 71, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '17:00:00', 'A32', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (21, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '17:30:00', 'A12', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (22, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '17:30:00', 'B46', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (23, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '17:30:00', 'B46', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (24, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP104', 'Yazılım Kurulumu ve Yönetimi', 51, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-02', '17:00:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (25, 'Bilgisayar Programcılığı', 'BPP1', 'IO', NULL, 'BPP105', 'Ofis Yazılımları', 55, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '17:00:00', 'A32', NULL, NULL, NULL, 0, 'Çetin YAĞCILAR', NULL, NULL);
INSERT INTO `guz` VALUES (26, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'BPP301', 'İnternet Proğramcılığı I', 69, 'Öğr.Gör.', 'Ersoy MEVSİM', '2017-12-25', '19:30:00', 'A32', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', 'Mustafa TEMEL', NULL);
INSERT INTO `guz` VALUES (27, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'BPP302', 'Nesne Tabanlı Programlama I', 71, 'Öğr.Gör.', 'Ersoy MEVSİM', '2019-04-08', '19:00:00', 'A32', NULL, NULL, NULL, 0, 'Öğr.Gör. Mustafa TEMEL', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (28, 'Bilgisayar Programcılığı', 'BPP3', 'G', NULL, 'BPP303', 'Açık Kaynak İşletim Sistemi', 64, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2017-12-26', '18:30:00', 'A32', NULL, NULL, NULL, 0, 'Ahmet AKBAY', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (29, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'BPP304', 'Ağ Temelleri', 66, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2017-12-27', '18:30:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (30, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'BPP305', 'Görsel Programlama I', 72, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '19:00:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (31, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'ÖMİ101', 'Mesleki Yabancı Dil I', 41, 'Okt.', 'Aysun ERTEKİN', '2017-12-28', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (32, 'Bilgisayar Programcılığı', 'BPP3', 'IO', NULL, 'KGS005', 'Kalite Güvence ve Standartları', 88, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '19:00:00', 'B42', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (33, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'BCT101', 'Genel Matemati', 53, 'Öğr.Gör.', 'Dilşat UNAKITAN', '2017-12-25', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (34, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'DAD001', 'Doğru Akım Devre Analizi', 98, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Erdal KILIÇ', 'Serap KAYIŞOĞLU', NULL);
INSERT INTO `guz` VALUES (35, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'BCT103', 'Anotomi ve Fizyoloji', 60, 'Doç.Dr.', 'Cengiz Mordeniz', '2018-01-02', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Cengiz Mordeniz', NULL, NULL);
INSERT INTO `guz` VALUES (36, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'BCT104', 'Arıza Analiz', 47, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-04', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (37, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 53, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A23', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (38, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'TDİ101', 'Türk Dili I', 53, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A23', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', NULL, NULL);
INSERT INTO `guz` VALUES (39, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 75, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'A32', NULL, NULL, NULL, 0, 'Fulya ÖZDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (40, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'İLY001', 'İlk yardım', 41, 'Doç.Dr.', 'Cengiz Mordeniz', '2018-01-03', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'Cengiz Mordeniz', NULL, NULL);
INSERT INTO `guz` VALUES (41, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'G', NULL, 'BCT102', 'Teknik Servis Organizasyo', 46, 'Öğr.Gör.', 'Duygu HÜYÜK', '2017-12-29', '16:00:00', 'B18', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (42, 'Biyomedikal Cihaz Teknolojisi', 'BCT1', 'IO', NULL, 'İŞY001', 'İşletme Yönetimi I', 99, 'Öğr.Gör.', 'Emre TEKİN', '2018-01-05', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (43, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT301', 'Yaşam Destek Cihazları', 61, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2017-12-25', '09:00:00', 'A32', NULL, NULL, NULL, 0, 'Ertuğrul KARAKULAK', NULL, NULL);
INSERT INTO `guz` VALUES (44, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT302', 'Laboratuvar Cihazları', 46, 'Öğr.Gör.Dr.', 'Aysel İÇÖZ', '2017-12-29', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (45, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT303', 'Destek Sistem ve Cihazları', 63, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2017-12-26', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'Ertuğrul KARAKULAK', NULL, NULL);
INSERT INTO `guz` VALUES (46, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT304', 'Tıbbi Görüntüleme Cihazları', 65, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2017-12-27', '09:00:00', 'A12', NULL, NULL, NULL, 0, 'Ertuğrul KARAKULAK', 'Ersoy MEVSİM', NULL);
INSERT INTO `guz` VALUES (47, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT305', 'Fizyolojik Sinyal İzleyicileri', 74, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2018-01-02', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', 'Ertuğrul KARAKULAK', NULL);
INSERT INTO `guz` VALUES (48, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'BCT306', 'Sterilizasyon Cihazları', 56, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2018-01-03', '09:00:00', 'B18', NULL, NULL, NULL, 0, 'Ertuğrul KARAKULAK', NULL, NULL);
INSERT INTO `guz` VALUES (49, 'Biyomedikal Cihaz Teknolojisi', 'BCT3', 'G', NULL, 'ÖMİ105', 'Mesleki Yabancı Dil I', 47, 'Okt.', 'Aysun ERTEKİN', '2017-12-28', '09:00:00', 'A12', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (50, 'Elektrik', 'ELP1', 'G', NULL, 'MAT109', 'Matematik', 49, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '15:00:00', 'A12', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (51, 'Elektrik', 'ELP1', 'G', NULL, 'BİT006', 'Bilgi ve İletişim Teknolojileri', 38, 'Öğr.Gör.Dr.', 'Emre TAHTABİÇEN', '2018-01-03', '13:00:00', 'A26', NULL, NULL, NULL, 0, 'Fulya ÖZDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (52, 'Elektrik', 'ELP1', 'G', NULL, 'ELP101', 'Ölçme Tekniği', 70, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '15:00:00', 'A32', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', 'Harun EKER', NULL);
INSERT INTO `guz` VALUES (53, 'Elektrik', 'ELP1', 'G', NULL, 'DAD005', 'Doğru Akım Devreleri', 116, 'Öğr.Gör.', 'Mücella CİHAN', '2017-12-28', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'Mücella CİHAN', 'Hatice ŞİMŞEK', NULL);
INSERT INTO `guz` VALUES (54, 'Elektrik', 'ELP1', 'G', NULL, 'ELP102', 'Tesisata Giriş', 55, 'Öğr.Gör.', 'Erhan KINALI', '2017-12-29', '14:00:00', 'A12', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (55, 'Elektrik', 'ELP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 47, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A33', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (56, 'Elektrik', 'ELP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 37, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A26', NULL, NULL, NULL, 0, 'Fulya ÖZDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (57, 'Elektrik', 'ELP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 44, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'B42', NULL, NULL, NULL, 0, 'Dilşat UNAKITAN', NULL, NULL);
INSERT INTO `guz` VALUES (58, 'Elektrik', 'ELP1', 'G', NULL, 'İGÜ002', 'İş Güvenliği', 41, 'Öğr.Gör.', 'Mücella CİHAN', '2018-01-05', '15:00:00', 'B70', NULL, NULL, NULL, 0, 'Mücella CİHAN', NULL, NULL);
INSERT INTO `guz` VALUES (59, 'Elektrik', 'ELP1', 'G', NULL, 'MSE001', 'Meslek Etiği', 45, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-04', '13:00:00', 'A33', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (60, 'Elektrik', 'ELP3', 'G', NULL, 'GET001', 'Güç Elektroniği', 104, 'Öğr.Gör.', 'Erhan KINALI', '2017-12-26', '09:00:00', 'B42', NULL, NULL, NULL, 0, 'Erhan KINALI', 'Mustafa TEMEL', NULL);
INSERT INTO `guz` VALUES (61, 'Elektrik', 'ELP3', 'G', NULL, 'ELP301', 'Asenkron ve Senkron Makinele', 94, 'Öğr.Gör.', 'Ahmet AKBAY', '2017-12-27', '09:00:00', 'B46', NULL, NULL, NULL, 0, 'Ahmet AKBAY', 'Dilşat UNAKITAN', NULL);
INSERT INTO `guz` VALUES (62, 'Elektrik', 'ELP3', 'G', NULL, 'ELP302', 'Elektrik Enerjisi Üretimi İletim ve Dağıtım', 110, 'Öğr.Gör.', 'Erhan KINALI', '2018-01-02', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KINALI', 'Mücella CİHAN', NULL);
INSERT INTO `guz` VALUES (63, 'Elektrik', 'ELP3', 'G', NULL, 'ELP303', 'Elektromekanik Kumanda Sistemler', 87, 'Öğr.Gör.', 'Mücella CİHAN', '2018-01-03', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Mücella CİHAN', 'Emre TAHTABİÇEN', NULL);
INSERT INTO `guz` VALUES (64, 'Elektrik', 'ELP3', 'G', NULL, 'ELP304', 'Arıza Analizi', 88, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-04', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', 'Ahmet AKBAY', NULL);
INSERT INTO `guz` VALUES (65, 'Elektrik', 'ELP3', 'G', NULL, 'SET001', 'Sayısal Elektronik', 109, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-29', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Mücella CİHAN', NULL);
INSERT INTO `guz` VALUES (66, 'Elektrik', 'ELP3', 'G', NULL, 'KGS007', 'Kalite Güvencesi ve Standartlar', 72, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '09:00:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (67, 'Elektrik', 'ELP1', 'IO', NULL, 'MAT109', 'Matematik', 0, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '18:30:00', 'A23', NULL, NULL, NULL, 0, 'H.İbrahim UZ', NULL, NULL);
INSERT INTO `guz` VALUES (68, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'BİT006', 'Bilgi ve İletişim Teknolojileri', 71, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '18:00:00', 'A31', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (69, 'Elektrik', 'ELP1', 'IO', NULL, 'ELP101', 'Ölçme Tekniği', 95, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '17:00:00', 'B46', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (70, 'Elektrik', 'ELP1', 'IO', NULL, 'DAD005', 'Doğru Akım Devreleri', 192, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '17:00:00', 'A23', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', 'Aytekin ERDEM', NULL);
INSERT INTO `guz` VALUES (71, 'Elektrik', 'ELP1', 'IO', NULL, 'ELP102', 'Tesisata Giriş', 36, 'Öğr.Gör.', 'Erhan KINALI', '2017-12-29', '18:00:00', 'B62', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (72, 'Elektrik', 'ELP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 108, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '17:30:00', 'A11', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (73, 'Elektrik', 'ELP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 107, 'Okt.', 'Levent TANER', '2017-12-26', '17:30:00', 'A23', NULL, NULL, NULL, 0, 'Mustafa TEMEL', NULL, NULL);
INSERT INTO `guz` VALUES (74, 'Elektrik', 'ELP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 131, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '17:30:00', 'A11', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (75, 'Elektrik', 'ELP1', 'G', NULL, 'İGÜ002', 'İş Güvenliği', 52, 'Öğr.Gör.', 'Mücella CİHAN', '2018-01-05', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Mücella CİHAN', NULL, NULL);
INSERT INTO `guz` VALUES (76, 'Elektrik', 'ELP1', 'IO', NULL, 'MSE001', 'Meslek Etiği', 16, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-04', '17:00:00', 'B63', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (77, 'Elektrik', 'ELP3', 'IO', NULL, 'GET001', 'Güç Elektroniği', 67, 'Öğr.Gör.', 'Mücella CİHAN', '2017-12-26', '19:30:00', 'B42', NULL, NULL, NULL, 0, 'Mücella CİHAN', 'Mustafa TEMEL', NULL);
INSERT INTO `guz` VALUES (78, 'Elektrik', 'ELP3', 'IO', NULL, 'ELP301', 'Asenkron ve Senkron Makinele', 54, 'Öğr.Gör.', 'Ahmet AKBAY', '2017-12-27', '19:30:00', 'A11', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (79, 'Elektrik', 'ELP3', 'IO', NULL, 'ELP302', 'Elektrik Enerjisi Üretimi İletim ve Dağıtım', 61, 'Öğr.Gör.', 'Erhan KINALI', '2018-01-02', '19:00:00', 'A12', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (80, 'Elektrik', 'ELP3', 'IO', NULL, 'ELP303', 'Elektromekanik Kumanda Sistemler', 49, 'Öğr.Gör.', 'Mücella CİHAN', '2018-01-03', '18:00:00', 'A11', NULL, NULL, NULL, 0, 'Mücella CİHAN', NULL, NULL);
INSERT INTO `guz` VALUES (81, 'Elektrik', 'ELP3', 'IO', NULL, 'ELP304', 'Arıza Analizi', 50, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-04', '19:00:00', 'A12', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (82, 'Elektrik', 'ELP3', 'IO', NULL, 'SET001', 'Sayısal Elektronik', 127, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-29', '17:00:00', 'B46', NULL, NULL, NULL, 0, 'Ahmet AKBAY', 'Özlem Bozkurt', NULL);
INSERT INTO `guz` VALUES (83, 'Elektrik', 'ELP3', 'IO', NULL, 'KGS007', 'Kalite Güvencesi ve Standartlar', 0, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '19:00:00', 'B47', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (84, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'GET001', 'Güç Elektroniği', 0, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-02', '10:00:00', 'B47', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', NULL, NULL);
INSERT INTO `guz` VALUES (85, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'GET001', 'Güç Elektroniği', 0, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-02', '19:00:00', 'B47', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (86, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'BDÇ001', 'Bilgisayar Destekli Çizim', 62, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '10:00:00', 'A12', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Figan DALMIŞ', NULL);
INSERT INTO `guz` VALUES (87, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'SAT103', 'Sistem Analizi ve Tasarımı I', 45, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-28', '18:00:00', 'A35', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', NULL, NULL);
INSERT INTO `guz` VALUES (88, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'ELM001', 'Elektrik Motorları', 78, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-27', '09:00:00', 'B70', NULL, NULL, NULL, 0, 'Zafer BAYRAM', 'Aysel İÇÖZ', NULL);
INSERT INTO `guz` VALUES (89, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'MKD001', 'Mikrodenetleyicile', 60, 'Öğr.Gör.', 'Duygu HÜYÜK', '2017-12-26', '10:00:00', 'A32', NULL, NULL, NULL, 0, 'Figan DALMIŞ', 'Duygu HÜYÜK', NULL);
INSERT INTO `guz` VALUES (90, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'PDN002', 'Programlanabilir Denetleyicile', 64, 'Yrd.Doç.', 'Gürcan UZAL', '2017-12-29', '10:00:00', 'B42', NULL, NULL, NULL, 0, 'Arzu GÖNÜLOL', 'Erdal KILIÇ', NULL);
INSERT INTO `guz` VALUES (91, 'Kontrol Otomasyon', 'KOP3', 'G', NULL, 'SYS002', 'Sayısal Tasarım', 58, 'S.Ö.E.', 'Cemil DURAN', '2018-01-03', '10:00:00', 'A32', NULL, NULL, NULL, 0, 'Cemil DURAN', NULL, NULL);
INSERT INTO `guz` VALUES (92, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'BDÇ001', 'Bilgisayar Destekli Çizim', 0, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (93, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'SAT103', 'Sistem Analizi ve Tasarımı I', 46, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-28', '10:00:00', 'A35', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', NULL, NULL);
INSERT INTO `guz` VALUES (94, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'ELM001', 'Elektrik Motorları', 39, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-27', '18:30:00', 'B62', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (95, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'MKD001', 'Mikrodenetleyicile', 45, 'Öğr.Gör.', 'Duygu HÜYÜK', '2017-12-26', '19:30:00', 'A23', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (96, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'PDN002', 'Programlanabilir Denetleyicile', 45, 'Yrd.Doç.', 'Gürcan UZAL', '2017-12-29', '19:00:00', 'A33', NULL, NULL, NULL, 0, 'Aytekin ERDEM', NULL, NULL);
INSERT INTO `guz` VALUES (97, 'Kontrol Otomasyon', 'KOP3', 'IO', NULL, 'SET002', 'Sayısal Tasarım', 38, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-03', '19:00:00', 'B62', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (98, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Levent TANER', '2017-12-26', '17:30:00', 'A32', NULL, NULL, NULL, 0, 'Levent TANER', NULL, NULL);
INSERT INTO `guz` VALUES (99, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '17:30:00', 'a11', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (100, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '17:30:00', 'A12', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (101, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 45, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'B47', NULL, NULL, NULL, 0, 'Dilşat UNAKITAN', NULL, NULL);
INSERT INTO `guz` VALUES (102, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 53, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'B70', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (103, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 61, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'A23', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (104, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'MTE003', 'Matemati', 38, 'Öğr.Gör.', 'Dilşat UNAKITAN', '2017-12-25', '15:00:00', 'B18', NULL, NULL, NULL, 0, 'Arzu GÖNÜLOL', NULL, NULL);
INSERT INTO `guz` VALUES (105, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'DAD004', 'Doğru Akım Devre Analizi', 79, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Sevilay GÜL', 'M.Barış EKMEKYAPAR', NULL);
INSERT INTO `guz` VALUES (106, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'ÖÇT003', 'Ölçme Tekniği', 55, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', NULL, NULL);
INSERT INTO `guz` VALUES (107, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'BİT007', 'Bilgi ve İletişim Teknolojileri', 29, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '13:00:00', 'a23', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (108, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'İŞY101', 'İşletme Yönetimi I', 57, 'Öğr.Gör.', 'Emre TEKİN', '2018-01-05', '14:00:00', 'A12', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (109, 'Kontrol Otomasyon', 'KOP1', 'G', NULL, 'FİZ001', 'Fizik', 41, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '15:00:00', 'A33', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (110, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'MTE003', 'Matemati', 69, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '18:30:00', 'a31', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (111, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'DAD005', 'Doğru Akım Devreleri', 0, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '17:00:00', 'A26', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (112, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'ÖÇT003', 'Ölçme Tekniği', 0, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '17:00:00', 'B47', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (113, 'Elektrik', 'ELP1', 'IO', NULL, 'BİT007', 'Bilgi ve İletişim Teknolojileri', 0, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '18:00:00', 'A23', NULL, NULL, NULL, 0, 'Çetin YAĞCILAR', NULL, NULL);
INSERT INTO `guz` VALUES (114, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'İŞY101', 'İşletme Yönetimi I', 0, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2018-01-05', '19:00:00', 'A26', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', NULL, NULL);
INSERT INTO `guz` VALUES (115, 'Kontrol Otomasyon', 'KOP1', 'IO', NULL, 'FİZ001', 'Fizik', 0, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '17:00:00', 'A33', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (116, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'GET002', 'Güç Elektroniği', 133, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-02', '10:00:00', 'B42', NULL, NULL, NULL, 0, 'Özlem Bozkurt', 'Figan DALMIŞ', NULL);
INSERT INTO `guz` VALUES (117, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'GET002', 'Güç Elektroniği', 94, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-02', '19:00:00', 'B46', NULL, NULL, NULL, 0, 'Ahmet AKBAY', NULL, NULL);
INSERT INTO `guz` VALUES (118, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'MAT105', 'Matematik', 34, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '15:00:00', 'B42', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (119, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'TBİ002', 'Teknolojinin Bilimsel İlkeleri', 52, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Emre TAHTABİÇEN', NULL, NULL);
INSERT INTO `guz` VALUES (120, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'DAD002', 'Doğru Akım Devre Analizi', 80, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '15:00:00', 'A32', NULL, NULL, NULL, 0, 'Hasan METE', 'Sinan CENGİZ', NULL);
INSERT INTO `guz` VALUES (121, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'SET002', 'Sayısal Elektronik', 84, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-29', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', 'Emre TAHTABİÇEN', NULL);
INSERT INTO `guz` VALUES (122, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'b70', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (123, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'b47', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (124, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'a23', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (125, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'BİT002', 'Bilgi ve İletişim Teknolojileri', 23, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '13:00:00', 'A23', NULL, NULL, NULL, 0, 'Çetin YAĞCILAR', NULL, NULL);
INSERT INTO `guz` VALUES (126, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'EHP102', 'Elektronik Ölçme Tekniği ve İş Güvenliği', 40, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '15:00:00', 'A12', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (127, 'Elektronik Haberleşme', 'EHP1', 'G', NULL, 'EHP103', 'Bilgisayar Donanımı', 28, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-05', '15:00:00', 'A33', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (128, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'EHP302', 'Mikroişlemciler / Mikrodenetleyiciler I', 44, 'Yrd.Doç.', 'Gürcan UZAL', '2017-12-29', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (129, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'EHP301', 'Analog Elektronik I', 65, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-03', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (130, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'EHP303', 'Sayısal Haberleşme', 51, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-26', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Fatih ÖZEN', NULL, NULL);
INSERT INTO `guz` VALUES (131, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'EHP304', 'Analog Haberleşme', 72, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-25', '10:00:00', 'A32', NULL, NULL, NULL, 0, 'Fatih ÖZEN', NULL, NULL);
INSERT INTO `guz` VALUES (132, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'SAT101', 'Sistem Analizi ve Tasarımı I', 50, 'Öğr.Gör.', 'Harun EKER', '2017-12-28', '10:00:00', 'A33', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (133, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'BDT101', 'Bilgisayar Destekli Tasarım II', 47, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2017-12-27', '09:00:00', 'A26', NULL, NULL, NULL, 0, 'Huzur DEVECİ', NULL, NULL);
INSERT INTO `guz` VALUES (134, 'Elektronik Haberleşme', 'EHP3', 'G', NULL, 'EHP305', 'Programlam', 77, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-02', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', 'Erhan KAHYA', NULL);
INSERT INTO `guz` VALUES (135, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'MMT103', 'Mesleki Matematik', 130, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KINALI', 'Şennur ASMA DELEN', NULL);
INSERT INTO `guz` VALUES (136, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'GTP101', 'Kimya I', 156, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2018-01-02', '13:00:00', 'A11', NULL, NULL, NULL, 0, 'Dilşat UNAKITAN', 'Mehmet CİVELEK', 'Sevilay GÜL');
INSERT INTO `guz` VALUES (137, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'GTP102', 'Genel Mikrobiyoloj', 85, 'Öğr.Gör.Dr.', 'Aysel İÇÖZ', '2018-01-03', '13:00:00', 'B46', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', 'Yasemin ÇİFTÇİ ŞENER', NULL);
INSERT INTO `guz` VALUES (138, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'GTP103', 'Gıdalarda Temel İşlemler I GTP1)', 136, 'Doç.Dr.', 'Hülya ORAK', '2017-12-28', '14:00:00', 'B18', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', 'Fulya ÖZDEMİR', 'Hülya ORAK');
INSERT INTO `guz` VALUES (139, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'GTP104', 'Gıda Kimyası', 555, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2017-12-29', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'Aytekin ERDEM', 'Gürcan UZAL', 'Serap KAYIŞOĞLU');
INSERT INTO `guz` VALUES (140, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 83, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A32', NULL, NULL, NULL, 0, 'Erhan KAHYA', 'Emre TAHTABİÇEN', NULL);
INSERT INTO `guz` VALUES (141, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 79, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A32', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', 'Mustafa TEMEL', NULL);
INSERT INTO `guz` VALUES (142, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 84, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'A26', NULL, NULL, NULL, 0, 'Figan DALMIŞ', 'Nazan ÖZCAN', NULL);
INSERT INTO `guz` VALUES (143, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'GTP105', 'Laboratuvar Tekniği', 151, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2018-01-04', '13:00:00', 'B42', NULL, NULL, NULL, 0, 'Erdal KILIÇ', 'Atila BABACAN', 'Fahriye Kuloğlu AKPINAR');
INSERT INTO `guz` VALUES (144, 'Gıda Teknolojisi', 'GTP1', 'G', NULL, 'ÇEV001', 'Çevre Koruma', 75, 'Yrd.Doç.', 'Abdullah YİNANÇ', '2018-01-05', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Ahmet BAL', 'Bahadır ALTÜRK', NULL);
INSERT INTO `guz` VALUES (145, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP301', 'Süt Teknolojisi I', 107, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2017-12-27', '09:00:00', 'A32', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', 'Hatice ŞİMŞEK', NULL);
INSERT INTO `guz` VALUES (146, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP302', 'Et ve Ürünleri Teknolojisi I', 96, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2017-12-29', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', 'Fulya ÖZDEMİR', NULL);
INSERT INTO `guz` VALUES (147, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP303', 'Meyve ve Sebze Teknolojisi I', 117, 'Doç.Dr.', 'Hülya ORAK', '2017-12-26', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Hülya ORAK', 'Emre TEKİN', NULL);
INSERT INTO `guz` VALUES (148, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP305', 'Bitkisel Yağ Teknolojisi', 141, 'Doç.Dr.', 'Hülya ORAK', '2018-01-03', '09:00:00', 'A12', NULL, NULL, NULL, 0, 'Aytekin ERDEM', 'Gürcan UZAL', 'Hülya ORAK');
INSERT INTO `guz` VALUES (149, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP304', 'Tahıl Teknolojisi I', 122, 'Yrd.Doç.', 'Hasan METE', '2017-12-28', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Nazan ÖZCAN', 'Hasan METE');
INSERT INTO `guz` VALUES (150, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP306', 'Ambalajlama ve Depolama Teknikler', 84, 'Yrd.Doç.', 'Hasan METE', '2018-01-02', '09:00:00', 'B46', NULL, NULL, NULL, 0, 'Hasan METE', 'Dilber YILDIZ', NULL);
INSERT INTO `guz` VALUES (151, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'GTP307', 'Biyoteknoloji', 74, 'Öğr.Gör.Dr.', 'Aysel İÇÖZ', '2018-01-04', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', 'M.Akif KARATAŞER', NULL);
INSERT INTO `guz` VALUES (152, 'Gıda Teknolojisi', 'GTP3', 'G', NULL, 'İŞY105', 'İşletme Yönetimi I', 28, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2018-01-05', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', NULL, NULL);
INSERT INTO `guz` VALUES (153, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'MMT103', 'Mesleki Matematik', 0, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '18:30:00', 'B42', NULL, NULL, NULL, 0, 'Fulya ÖZDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (154, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'GTP101', 'Kimya I', 105, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2018-01-02', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', 'Gürcan UZAL', NULL);
INSERT INTO `guz` VALUES (155, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'GTP102', 'Genel Mikrobiyoloji', 21, 'Öğr.Gör.Dr.', 'Aysel İÇÖZ', '2018-01-03', '17:00:00', 'B62', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (156, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'GTP103', 'Gıdalarda Temel İşlemler I', 72, 'Doç.Dr.', 'Hülya ORAK', '2017-12-28', '17:00:00', 'B46', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', 'Hülya ORAK', NULL);
INSERT INTO `guz` VALUES (157, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'GTP104', 'Gıda Kimyası', 97, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2017-12-29', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', 'Serkan TUĞ', NULL);
INSERT INTO `guz` VALUES (158, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 140, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '17:30:00', 'B18', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (159, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 115, 'Okt.', 'Turay YAYLA', '2017-12-26', '17:30:00', 'A11', NULL, NULL, NULL, 0, 'Turay YAYLA', NULL, NULL);
INSERT INTO `guz` VALUES (160, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 122, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '17:30:00', 'B42', NULL, NULL, NULL, 0, 'H.İbrahim UZ', NULL, NULL);
INSERT INTO `guz` VALUES (161, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'GTP105', 'Laboratuvar Tekniği', 83, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2018-01-04', '17:00:00', 'B42', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', 'Duygu HÜYÜK', NULL);
INSERT INTO `guz` VALUES (162, 'Gıda Teknolojisi', 'GTP1', 'IO', NULL, 'ÇEV001', 'Çevre Koruma', 12, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2018-01-05', '17:00:00', 'B66', NULL, NULL, NULL, 0, 'Huzur DEVECİ', NULL, NULL);
INSERT INTO `guz` VALUES (163, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP301', 'Süt Teknolojisi I B', 42, 'Prof.Dr.', 'Bilal BİLGİN', '2017-12-27', '18:30:00', 'A23', NULL, NULL, NULL, 0, 'Hasan METE', NULL, NULL);
INSERT INTO `guz` VALUES (164, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP301', 'Süt Teknolojisi I  A', 56, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2017-12-27', '18:30:00', 'A11', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', NULL, NULL);
INSERT INTO `guz` VALUES (165, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP302', 'Et ve Ürünleri Teknolojisi I  B', 53, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2017-12-29', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Cevdet ARITAŞI', NULL, NULL);
INSERT INTO `guz` VALUES (166, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP302', 'Et ve Ürünleri Teknolojisi I  A', 46, 'Prof.Dr.', 'Bilal BİLGİN', '2017-12-29', '19:00:00', 'A23', NULL, NULL, NULL, 0, 'Fatih ÖZEN', NULL, NULL);
INSERT INTO `guz` VALUES (167, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP303', 'Meyve ve Sebze Teknolojisi', 95, 'Doç.Dr.', 'Hülya ORAK', '2017-12-26', '18:30:00', 'A11', NULL, NULL, NULL, 0, 'Hülya ORAK', 'Mücella CİHAN', NULL);
INSERT INTO `guz` VALUES (168, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP305', 'Bitkisel Yağ Teknolojisi', 110, 'Doç.Dr.', 'Hülya ORAK', '2018-01-03', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Hülya ORAK', 'Aysel İÇÖZ', NULL);
INSERT INTO `guz` VALUES (169, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP304', 'Tahıl Teknolojisi I', 113, 'Yrd.Doç.', 'Hasan METE', '2017-12-28', '19:00:00', 'A23', NULL, NULL, NULL, 0, 'Huzur DEVECİ', 'Hasan METE', NULL);
INSERT INTO `guz` VALUES (170, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP306', 'Ambalajlama ve Depolama Teknikler', 59, 'Yrd.Doç.', 'Hasan METE', '2018-01-02', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Hasan METE', NULL, NULL);
INSERT INTO `guz` VALUES (171, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'GTP307', 'Biyoteknoloj', 54, 'Öğr.Gör.Dr.', 'Aysel İÇÖZ', '2018-01-04', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (172, 'Gıda Teknolojisi', 'GTP3', 'IO', NULL, 'İŞY105', 'İşletme Yönetimi I', 136, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2018-01-05', '19:00:00', 'A11', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (173, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'MMT101', 'Mesleki Matematik', 25, 'Öğr.Gör.', 'Dilşat UNAKITAN', '2017-12-25', '15:00:00', 'A31', NULL, NULL, NULL, 0, 'Huzur DEVECİ', NULL, NULL);
INSERT INTO `guz` VALUES (174, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP101', 'Hazır Giyim Üretimi I', 6, 'Öğr.Gör.', 'Dilber YILDIZ', '2018-01-02', '13:00:00', 'B44', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (175, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP102', 'Kalıp Hazırlama Teknikleri I', 8, 'Öğr.Gör.', 'Dilber YILDIZ', '2018-01-03', '13:00:00', 'B19', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (176, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP103', 'Temel Sanat Eğitimi', 9, 'Öğr.Gör.', 'Nazan ÖZCAN', '2017-12-28', '14:00:00', 'B19', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (177, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'b62', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (178, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'b62', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (179, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '12:30:00', 'b62', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (180, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP104', 'Konfeksiyon Yardımcı Malzemeleri', 6, 'Öğr.Gör.', 'Dilber YILDIZ', '2018-01-04', '13:00:00', 'B44', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (181, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP105', 'Konfeksiyonda Kalite Kontrol', 30, 'Öğr.Gör.', 'Nazan ÖZCAN', '2017-12-29', '13:00:00', 'B62', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (182, 'Giyim Üretim Teknolojisi', 'GÜP1', 'G', NULL, 'GÜP106', 'Moda', 18, 'Öğr.Gör.', 'Dilber YILDIZ', '2018-01-05', '15:00:00', 'B44', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (183, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP301', 'Hazır Giyim Üretimi III', 29, 'Öğr.Gör.', 'Nazan ÖZCAN', '2017-12-26', '09:00:00', 'B19', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (184, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP302', 'Kalıp Hazırlama Teknikleri III', 30, 'Öğr.Gör.', 'Dilber YILDIZ', '2017-12-28', '09:00:00', 'B44', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (185, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP303', 'Üretim Planlaması', 38, 'Öğr.Gör.', 'Nazan ÖZCAN', '2017-12-27', '10:00:00', 'B42', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (186, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP304', 'Çocuk Giysi Üretimi', 27, 'Öğr.Gör.', 'Nazan ÖZCAN', '2018-01-03', '09:00:00', 'B19', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (187, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP305', 'Giysi Tasarımı I', 31, 'Öğr.Gör.', 'Nazan ÖZCAN', '2018-01-05', '09:00:00', 'B19', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', NULL, NULL);
INSERT INTO `guz` VALUES (188, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'GÜP306', 'Sanat Tarih I', 28, 'Öğr.Gör.', 'Dilber YILDIZ', '2017-12-25', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (189, 'Giyim Üretim Teknolojisi', 'GÜP3', 'G', NULL, 'KGS007', 'Kalite Güvence Standartları', 28, 'Öğr.Gör.Dr.', 'Emre TAHTABİÇEN', '2017-12-29', '09:00:00', 'B41', NULL, NULL, NULL, 0, 'Emre TAHTABİÇEN', NULL, NULL);
INSERT INTO `guz` VALUES (190, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'MMT105', 'Mesleki Matematik', 62, 'Öğr.Gör.', 'Dilşat UNAKITAN', '2017-12-25', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (191, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'İSP101', 'Kaynak Teknolojisi', 27, 'Öğr.Gör.', 'M.Akif KARATAŞER', '2018-01-02', '11:00:00', 'A26', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (192, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'İSP102', 'İklimlendirme ve Soğutma Teknolojileri', 66, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-28', '13:00:00', 'B42', NULL, NULL, NULL, 0, 'Serap AKDEMİR', 'Hatice ŞİMŞEK', NULL);
INSERT INTO `guz` VALUES (193, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'İGÜ003', 'İş Güvenliği', 15, 'Öğr.Gör.', 'M.Akif KARATAŞER', '2018-01-04', '13:00:00', 'A31', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (194, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 37, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B62', NULL, NULL, NULL, 0, 'Arzu GÖNÜLOL', NULL, NULL);
INSERT INTO `guz` VALUES (195, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 15, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'b18', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (196, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 34, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '12:30:00', 'B62', NULL, NULL, NULL, 0, 'Güray KARADUMAN', NULL, NULL);
INSERT INTO `guz` VALUES (197, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'BİT003', 'Bilgi ve İletişim Teknolojileri', 37, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '13:00:00', 'B18', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (198, 'İklimlendirme Soğutma Teknolojisi', 'ISP1', 'G', NULL, 'FİZ004', 'Fizik', 82, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-29', '14:00:00', 'B62', NULL, NULL, NULL, 0, 'Mücella CİHAN', 'Hakan MUTLU', NULL);
INSERT INTO `guz` VALUES (199, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP301', 'Elektromekanik Kumanda Devreleri', 51, 'Öğr.Gör.', 'Mücella CİHAN', '2017-12-25', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Mücella CİHAN', NULL, NULL);
INSERT INTO `guz` VALUES (200, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP302', 'Ticari Soğutma Sistemleri', 94, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-26', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Serap AKDEMİR', 'Hakan MUTLU', NULL);
INSERT INTO `guz` VALUES (201, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP303', 'Isıtma Sistemleri', 70, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '10:00:00', 'B62', NULL, NULL, NULL, 0, 'Hakan MUTLU', 'Serkan TUĞ', NULL);
INSERT INTO `guz` VALUES (202, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP304', 'Bireysel İklimlendirme Sistemleri', 76, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-28', '09:00:00', 'B62', NULL, NULL, NULL, 0, 'Hakan MUTLU', 'H.İbrahim UZ', NULL);
INSERT INTO `guz` VALUES (203, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP305', 'Doğalgaz Tesisatı', 57, 'Öğr.Gör.', 'Hakan MUTLU', '2018-01-02', '10:00:00', 'A32', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (204, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP306', 'Tesisat İşlemleri', 51, 'Öğr.Gör.', 'Hakan MUTLU', '2018-01-03', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (205, 'İklimlendirme Soğutma Teknolojisi', 'ISP3', 'G', NULL, 'İSP307', 'Taşıt İklimlendirmesi', 40, 'Doc. Dr. ', 'Ahmet Kaya', '2018-01-04', '11:00:00', 'A23', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (206, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'MAT107', 'Matematik I', 80, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-25', '14:00:00', 'B42', NULL, NULL, NULL, 0, 'Emre TEKİN', 'Mücella CİHAN', NULL);
INSERT INTO `guz` VALUES (207, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'INP101', 'Mekanik ve Stati', 120, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2018-01-02', '13:00:00', 'B46', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', 'Bahadır ALTÜRK', 'Huzur DEVECİ');
INSERT INTO `guz` VALUES (208, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'TKR001', 'Teknik Resim', 117, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-26', '09:00:00', 'A36', NULL, NULL, NULL, 0, 'Yunus GÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (209, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'INP102', 'Yapı Malzemeleri', 99, 'Öğr.Gör.', 'M.Barış EKMEKYAPAR', '2017-12-28', '13:00:00', 'A11', NULL, NULL, NULL, 0, 'Huzur DEVECİ', 'Bahadır ALTÜRK', NULL);
INSERT INTO `guz` VALUES (210, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 111, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A11', NULL, NULL, NULL, 0, 'Huzur DEVECİ', NULL, NULL);
INSERT INTO `guz` VALUES (211, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 108, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A11', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (212, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 130, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'A11', NULL, NULL, NULL, 0, 'Ahmet BAL', NULL, NULL);
INSERT INTO `guz` VALUES (213, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'BİT006', 'Bilgi ve İletişim Teknolojileri', 78, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '13:00:00', 'B62', NULL, NULL, NULL, 0, 'Arzu GÖNÜLOL', 'Fikret YIKILMAZ', NULL);
INSERT INTO `guz` VALUES (214, 'İnşaat Teknolojisi', 'INP1', 'G', NULL, 'INP103', 'Meslekî Uygulamalar', 83, 'S.Ö.E.', 'Ahmet UZUN', '2017-12-29', '16:00:00', 'B42', NULL, NULL, NULL, 0, 'Ahmet UZUN', 'Ahmet BAL', NULL);
INSERT INTO `guz` VALUES (215, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'BDÇ001', 'Bilgisayar Destekli Çizim', 50, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2017-12-27', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', NULL, NULL);
INSERT INTO `guz` VALUES (216, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'INP301', 'Zemin Mekaniği I', 144, 'Öğr.Gör.', 'Ahmet BAL', '2017-12-25', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Dilşat UNAKITAN', 'Aysun ERTEKİN', NULL);
INSERT INTO `guz` VALUES (217, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'INP302', 'Yapı Metrajı ve Maliyeti', 150, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2017-12-28', '09:00:00', 'B18', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', 'Ahmet BAL', NULL);
INSERT INTO `guz` VALUES (218, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'BET001', 'Betonarm', 207, 'Öğr.Gör.', 'M.Barış EKMEKYAPAR', '2017-12-29', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Ahmet BAL', 'Huzur DEVECİ', NULL);
INSERT INTO `guz` VALUES (219, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'INP304', 'Çelik Yapılar', 141, 'Öğr.Gör.', 'Ahmet BAL', '2018-01-02', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'Hakan MUTLU', 'Yasemin ÇİFTÇİ ŞENER', NULL);
INSERT INTO `guz` VALUES (220, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'INP305', 'Yapı Tesisatları', 54, 'S.Ö.E.', 'Ahmet UZUN', '2018-01-04', '11:00:00', 'A11', NULL, NULL, NULL, 0, 'Ahmet UZUN', NULL, NULL);
INSERT INTO `guz` VALUES (221, 'İnşaat Teknolojisi', 'INP3', 'G', NULL, 'INP306', 'Şantiye Organizasyonu', 118, 'Öğr.Gör.', 'Ahmet BAL', '2018-01-03', '09:00:00', 'B42', NULL, NULL, NULL, 0, 'Emre TEKİN', 'H.İbrahim UZ', NULL);
INSERT INTO `guz` VALUES (222, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'ETP303', 'Sensörler ve Dönüştürücüler', 78, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-26', '11:00:00', 'B46', NULL, NULL, NULL, 0, 'Fatih ÖZEN', 'Mustafa TEMEL', NULL);
INSERT INTO `guz` VALUES (223, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'BDÇ001', 'Bilgisayar Destekli Çizim', 82, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', 'Harun EKER', NULL);
INSERT INTO `guz` VALUES (224, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'MKD001', 'Mikrodenetleyicile', 75, 'Yrd.Doç.', 'Gürcan UZAL', '2017-12-29', '10:00:00', 'B62', NULL, NULL, NULL, 0, 'Sevilay GÜL', 'Hasan METE', NULL);
INSERT INTO `guz` VALUES (225, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'ETP301', 'Elektronik I', 73, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-03', '10:00:00', 'A12', NULL, NULL, NULL, 0, 'H.İbrahim UZ', 'Dilber YILDIZ', NULL);
INSERT INTO `guz` VALUES (226, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'SAT101', 'Sistem Analizi ve Tasarımı I', 71, 'Öğr.Gör.', 'Zafer BAYRAM', '2018-01-05', '10:00:00', 'B63', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (227, 'Elektronik Teknolojisi', 'ETP3', 'G', NULL, 'ETP302', 'Kontrol Sistemler', 95, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-27', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Fatih ÖZEN', 'Emre TAHTABİÇEN', NULL);
INSERT INTO `guz` VALUES (228, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'BDÇ001', 'Bilgisayar Destekli Çizim', 0, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '17:00:00', 'A12', NULL, NULL, NULL, 0, 'Fulya ÖZDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (229, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'MKD001', 'Mikrodenetleyicile', 54, 'Yrd.Doç.', 'Gürcan UZAL', '2017-12-29', '19:00:00', 'A32', NULL, NULL, NULL, 0, 'Gürcan UZAL', NULL, NULL);
INSERT INTO `guz` VALUES (230, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'ETP301', 'Elektronik I', 58, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-03', '19:00:00', 'A23', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (231, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'SAT101', 'Sistem Analizi ve Tasarımı I', 50, 'Öğr.Gör.', 'Zafer BAYRAM', '2018-01-05', '19:00:00', 'B63', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (232, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'ETP302', 'Kontrol Sistemler', 59, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-27', '18:30:00', 'A12', NULL, NULL, NULL, 0, 'Fatih ÖZEN', NULL, NULL);
INSERT INTO `guz` VALUES (233, 'Elektronik Teknolojisi', 'ETP3', 'IO', NULL, 'ETP303', 'Sensörler ve Dönüştürücüler', 49, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-26', '18:30:00', 'A23', NULL, NULL, NULL, 0, 'Fatih ÖZEN', NULL, NULL);
INSERT INTO `guz` VALUES (234, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '17:30:00', 'a11', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (235, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '17:30:00', 'b18', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (236, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '17:30:00', 'b42', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (237, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'ETP101', 'Genel Matemati', 50, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '15:00:00', 'A32', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (238, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'DAD003', 'Doğru Akım Devre Analizi', 99, 'Öğr.Gör.', 'Fatih ÖZEN', '2017-12-28', '13:00:00', 'A32', NULL, NULL, NULL, 0, 'Fatih ÖZEN', 'Emre TEKİN', NULL);
INSERT INTO `guz` VALUES (239, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'SET001', 'Sayısal Elektronik', 98, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-29', '15:00:00', 'A32', NULL, NULL, NULL, 0, 'Özlem Bozkurt', 'Zafer BAYRAM', NULL);
INSERT INTO `guz` VALUES (240, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'ETP103', 'Ölçme Tekniği', 82, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Arzu GÖNÜLOL', 'Elif YÜKSEL TÜRKBOYLARI', NULL);
INSERT INTO `guz` VALUES (241, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'ETP105', 'Elektronik Meslek Bilgisi ve Güvenlik', 53, 'Öğr.Gör.', 'Harun EKER', '2018-01-04', '13:00:00', 'A12', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (242, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 29, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A33', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (243, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 24, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A26', NULL, NULL, NULL, 0, 'Aysel İÇÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (244, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 48, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'B18', NULL, NULL, NULL, 0, 'H.İbrahim UZ', NULL, NULL);
INSERT INTO `guz` VALUES (245, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'BİT002', 'Bilgi ve İletişim Teknolojileri', 38, 'Öğr.Gör.Dr.', 'Emre TAHTABİÇEN', '2018-01-03', '13:00:00', 'A23', NULL, NULL, NULL, 0, 'Emre TAHTABİÇEN', NULL, NULL);
INSERT INTO `guz` VALUES (246, 'Elektronik Teknolojisi', 'ETP1', 'G', NULL, 'İLŞ001', 'İletişim', 30, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-05', '15:00:00', 'A12', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (247, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'ETP101', 'Genel Matemati', 85, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '18:30:00', 'B18', NULL, NULL, NULL, 0, 'Çetin YAĞCILAR', NULL, NULL);
INSERT INTO `guz` VALUES (248, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'DAD005', 'Doğru Akım Devreleri', 0, 'Yrd.Doç.', 'Aytekin ERDEM', '2017-12-28', '17:00:00', 'A32', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (249, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'SET001', 'Sayısal Elektronik', 0, 'Öğr.Gör.', 'Zafer BAYRAM', '2017-12-29', '17:00:00', 'B70', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (250, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'ETP103', 'Ölçme Tekniği', 0, 'Öğr.Gör.', 'Ahmet AKBAY', '2018-01-02', '17:00:00', 'b47', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (251, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'ETP105', 'Elektronik Meslek Bilgisi ve Güvenlik', 23, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '17:00:00', 'A26', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (252, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'BİT002', 'Bilgi ve İletişim Teknolojileri', 0, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '18:00:00', 'a23', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (253, 'Elektronik Teknolojisi', 'ETP1', 'IO', NULL, 'İLŞ001', 'İletişim', 60, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-05', '18:00:00', 'B46', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (254, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'MAT101', 'Matematik', 72, 'Öğr.Gör.', 'Dilşat UNAKITAN', '2017-12-25', '15:00:00', 'A26', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', 'Emre TAHTABİÇEN', NULL);
INSERT INTO `guz` VALUES (255, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'TKR101', 'Teknik  Resim', 86, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-28', '09:00:00', 'A36', NULL, NULL, NULL, 0, 'Yunus GÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (256, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'MRP101', 'Temel İmalat İşlemleri', 52, 'S.Ö.E.', 'Hüseyin METİNER', '2018-01-04', '09:00:00', 'Mak.Atel', NULL, NULL, NULL, 0, 'Hüseyin Metiner', NULL, NULL);
INSERT INTO `guz` VALUES (257, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'MRP102', 'Malzeme Teknolojisi', 45, 'Öğr.Gör.', 'M.Akif KARATAŞER', '2018-01-02', '13:00:00', 'B62', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (258, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 31, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'B62', NULL, NULL, NULL, 0, 'Fahriye Kuloğlu AKPINAR', NULL, NULL);
INSERT INTO `guz` VALUES (259, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 36, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B42', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', NULL, NULL);
INSERT INTO `guz` VALUES (260, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 43, 'Okt.', 'Nurtekin CURA', '2017-12-27', '17:30:00', 'A11', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (261, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'FİZ004', 'Fizik', 85, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-29', '14:00:00', 'B46', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Nazan ÖZCAN', NULL);
INSERT INTO `guz` VALUES (262, 'Makine Resim Konstrüksion', 'MRP1', 'G', NULL, 'BİT001', 'Bilgi ve İletişim Teknolojileri', 34, 'Öğr.Gör.Dr.', 'Erhan KAHYA', '2018-01-03', '13:00:00', 'b18', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (263, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP301', 'Makine  Elemanları I', 101, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '11:00:00', 'A23', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', 'Serkan TUĞ', NULL);
INSERT INTO `guz` VALUES (264, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'BDT004', 'Bilgisayar Destekli Tasarım', 70, 'Öğr.Gör.Dr.', 'Serkan TUĞ', '2017-12-26', '09:00:00', 'A26', NULL, NULL, NULL, 0, 'Serkan TUĞ', 'Elif YÜKSEL TÜRKBOYLARI', NULL);
INSERT INTO `guz` VALUES (265, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP302', 'Makine Tasarımı', 62, 'Öğr.Gör.Dr.', 'Serkan TUĞ', '2018-01-04', '11:00:00', 'A12', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (266, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP303', 'Aparat Tasarımı', 64, 'Yrd.Doç.', 'Atila BABACAN', '2017-12-28', '13:00:00', 'Mak.Atel', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (267, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP304', 'Fabrika Organizasyo', 44, 'Doç.Dr.', 'Serap AKDEMİR', '2018-01-02', '09:00:00', 'B18', NULL, NULL, NULL, 0, 'Serap AKDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (268, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP305', 'Sac Metal Kalıp Tasarımı', 83, 'Öğr.Gör.', 'Hatice ŞİMŞEK', '2017-12-29', '11:00:00', 'B62', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', 'Dilber YILDIZ', NULL);
INSERT INTO `guz` VALUES (269, 'Makine Resim Konstrüksion', 'MRP3', 'G', NULL, 'MRP306', 'Mekanizma Tekniği', 72, 'Öğr.Gör.', 'Hatice ŞİMŞEK', '2018-01-03', '10:00:00', 'B62', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', 'Emre TEKİN', NULL);
INSERT INTO `guz` VALUES (270, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'MAT101', 'Matematik', 0, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-25', '18:30:00', 'B47', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (271, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'TKR101', 'Teknik  Resim', 105, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-28', '17:00:00', 'a36', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (272, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'MRP101', 'Temel İmalat İşlemleri', 10, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-29', '17:00:00', 'B41', NULL, NULL, NULL, 0, 'Serap AKDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (273, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'MRP102', 'Malzeme Teknolojisi', 20, 'Öğr.Gör.', 'M.Akif KARATAŞER', '2018-01-02', '17:00:00', 'A31', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (274, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '17:30:00', 'a11', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (275, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '17:30:00', 'B42', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (276, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '17:30:00', 'B47', NULL, NULL, NULL, 0, 'Güray KARADUMAN', NULL, NULL);
INSERT INTO `guz` VALUES (277, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'FİZ004', 'Fizik', 0, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '17:00:00', 'A23', NULL, NULL, NULL, 0, 'Fahriye Kuloğlu AKPINAR', NULL, NULL);
INSERT INTO `guz` VALUES (278, 'Makine Resim Konstrüksion', 'MRP1', 'IO', NULL, 'BİT001', 'Bilgi ve İletişim Teknolojisi', 0, 'Öğr.Gör.Dr.', 'Çetin YAĞCILAR', '2018-01-04', '18:00:00', 'a31', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (279, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP301', 'Makine  Elemanları I', 50, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '19:30:00', 'A12', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (280, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'BDT004', 'Bilgisayar Destekli Tasarım', 34, 'Öğr.Gör.Dr.', 'Serkan TUĞ', '2017-12-26', '19:30:00', 'B62', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (281, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP302', 'Makine Tasarımı', 39, 'Öğr.Gör.', 'Hakan MUTLU', '2018-01-04', '19:00:00', 'B47', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (282, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP303', 'Aparat Tasarımı', 37, 'Yrd.Doç.', 'Atila BABACAN', '2017-12-28', '19:00:00', 'Mak.Atel', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (283, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP304', 'Fabrika Organizasyo', 31, 'Doç.Dr.', 'Serap AKDEMİR', '2018-01-02', '18:00:00', 'B42', NULL, NULL, NULL, 0, 'Serap AKDEMİR', NULL, NULL);
INSERT INTO `guz` VALUES (284, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP305', 'Sac Metal Kalıp Tasarımı', 44, 'Öğr.Gör.', 'Hatice ŞİMŞEK', '2017-12-29', '18:00:00', 'B70', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (285, 'Makine Resim Konstrüksion', 'MRP3', 'IO', NULL, 'MRP306', 'Mekanizma Tekniği', 43, 'Öğr.Gör.', 'Hatice ŞİMŞEK', '2018-01-03', '19:00:00', 'B70', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (286, 'Makine', 'MKP1', 'G', NULL, 'MTE001', 'Matemati', 73, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'Nazan ÖZCAN', 'Aysel İÇÖZ', NULL);
INSERT INTO `guz` VALUES (287, 'Makine', 'MKP1', 'G', NULL, 'TKR003', 'Teknik Resim', 109, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-28', '13:00:00', 'A36', NULL, NULL, NULL, 0, 'Yunus GÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (288, 'Makine', 'MKP1', 'G', NULL, 'MKP101', 'Temel İmalat İşlemleri', 79, 'Yrd.Doç.', 'Atila BABACAN', '2018-01-02', '13:00:00', 'Mak.Atel.', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (289, 'Makine', 'MKP1', 'G', NULL, 'BDÇ101', 'Bilgisayar Destekli Çizim I', 53, 'Öğr.Gör.', 'Hatice ŞİMŞEK', '2018-01-03', '14:00:00', 'A32', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (290, 'Makine', 'MKP1', 'G', NULL, 'FİZ004', 'Fizik', 148, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-29', '16:00:00', 'A23', NULL, NULL, NULL, 0, 'Serkan TUĞ', 'Serap KAYIŞOĞLU', 'Serap AKDEMİR');
INSERT INTO `guz` VALUES (291, 'Makine', 'MKP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 40, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'B70', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (292, 'Makine', 'MKP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 54, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B47', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (293, 'Makine', 'MKP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 58, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '12:30:00', 'B70', NULL, NULL, NULL, 0, 'Ersoy MEVSİM', NULL, NULL);
INSERT INTO `guz` VALUES (294, 'Makine', 'MKP1', 'G', NULL, 'MKP102', 'Ölçme ve Kontrol', 69, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2017-12-29', '15:00:00', 'B41', NULL, NULL, NULL, 0, 'Sinan CENGİZ', 'Arzu GÖNÜLOL', NULL);
INSERT INTO `guz` VALUES (295, 'Makine', 'MKP1', 'G', NULL, 'İGÜ002', 'İş Güvenliği', 61, 'Öğr.Gör.', 'M.Akif KARATAŞER', '2018-01-04', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (296, 'Makine', 'MKP3', 'G', NULL, 'MKP301', 'Termodinami', 97, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-26', '09:00:00', 'B18', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', 'Serap AKDEMİR', NULL);
INSERT INTO `guz` VALUES (297, 'Makine', 'MKP3', 'G', NULL, 'MKP302', 'Makine Elemanları', 115, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '11:00:00', 'A11', NULL, NULL, NULL, 0, 'Dilşat UNAKITAN', 'Aysun ERTEKİN', NULL);
INSERT INTO `guz` VALUES (298, 'Makine', 'MKP3', 'G', NULL, 'MKP303', 'İmalat İşlemleri II', 79, 'Yrd.Doç.', 'Atila BABACAN', '2018-01-03', '09:00:00', 'Mak.Atel', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (299, 'Makine', 'MKP3', 'G', NULL, 'BDÜ101', 'Bilgisayar Destekli Üretim I', 86, 'Öğr.Gör.Dr.', 'Serkan TUĞ', '2017-12-29', '09:00:00', 'A51', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (300, 'Makine', 'MKP3', 'G', NULL, 'MKP304', 'CNC Freze Teknolojis', 74, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2018-01-02', '09:00:00', 'A23', NULL, NULL, NULL, 0, 'Zafer BAYRAM', 'Sinan CENGİZ', NULL);
INSERT INTO `guz` VALUES (301, 'Makine', 'MKP3', 'G', NULL, 'MKP305', 'Kaynak Teknolojisi', 50, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2018-01-04', '09:00:00', 'A32', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (302, 'Makine', 'MKP3', 'G', NULL, 'İLŞ003', 'İletişim', 62, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-05', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (303, 'Makine', 'MKP1', 'IO', NULL, 'MTE001', 'Matemati', 0, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '18:30:00', 'A31', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (304, 'Makine', 'MKP1', 'IO', NULL, 'TKR003', 'Teknik Resim', 0, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-28', '17:00:00', 'A36', NULL, NULL, NULL, 0, 'Yunus GÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (305, 'Makine', 'MKP1', 'IO', NULL, 'MKP101', 'Temel İmalat İşlemleri', 48, 'Yrd.Doç.', 'Atila BABACAN', '2018-01-02', '17:00:00', 'Mak.Atel.', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (306, 'Makine', 'MKP1', 'IO', NULL, 'BDÇ101', 'Bilgisayar Destekli Çizim I', 177, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '17:00:00', 'A23', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (307, 'Makine', 'MKP1', 'IO', NULL, 'FİZ004', 'Fizik', 237, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '17:00:00', 'A11', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (308, 'Makine', 'MKP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Levent TANER', '2017-12-26', '17:30:00', 'a32', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (309, 'Makine', 'MKP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '17:30:00', 'A12', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (310, 'Makine', 'MKP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '17:30:00', 'a12', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (311, 'Makine', 'MKP1', 'IO', NULL, 'MKP102', 'Ölçme ve Kontrol', 65, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2017-12-29', '17:00:00', 'A32', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (312, 'Makine', 'MKP1', 'IO', NULL, 'İGÜ002', 'İş Güvenliği', 0, 'Öğr.Gör.', 'Mücella CİHAN', '2018-01-05', '17:00:00', 'a11', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (313, 'Makine', 'MKP3', 'IO', NULL, 'MKP301', 'Termodinami', 61, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-26', '18:30:00', 'B41', NULL, NULL, NULL, 0, 'Serap AKDEMİR', 'Atila BABACAN', NULL);
INSERT INTO `guz` VALUES (314, 'Makine', 'MKP3', 'IO', NULL, 'MKP302', 'Makine Elemanları', 118, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '19:30:00', 'A23', NULL, NULL, NULL, 0, 'Erhan KAHYA', NULL, NULL);
INSERT INTO `guz` VALUES (315, 'Makine', 'MKP3', 'IO', NULL, 'MKP303', 'İmalat İşlemleri II', 56, 'Yrd.Doç.', 'Atila BABACAN', '2018-01-03', '18:00:00', 'Mak.Atel', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (316, 'Makine', 'MKP3', 'IO', NULL, 'BDÜ101', 'Bilgisayar Destekli Üretim I', 47, 'Öğr.Gör.Dr.', 'Serkan TUĞ', '2017-12-29', '19:00:00', 'A51', NULL, NULL, NULL, 0, 'Serkan TUĞ', NULL, NULL);
INSERT INTO `guz` VALUES (317, 'Makine', 'MKP3', 'IO', NULL, 'MKP304', 'CNC Freze Teknolojis', 46, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2018-01-02', '19:00:00', 'A23', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (318, 'Makine', 'MKP3', 'IO', NULL, 'MKP305', 'Kaynak Teknolojisi', 43, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2018-01-04', '18:00:00', 'A32', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (319, 'Makine', 'MKP3', 'IO', NULL, 'İLŞ003', 'İletişim', 0, 'Okt.', 'Tekin ÖZTÜRK', '2018-01-05', '18:00:00', 'b46', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (320, 'Mekatronik', 'MEP1', 'G', NULL, 'BDT001', 'Bilgisayar Destekli Tasarım', 69, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-04', '10:00:00', 'A33', NULL, NULL, NULL, 0, 'H.İbrahim UZ', 'Dilber YILDIZ', NULL);
INSERT INTO `guz` VALUES (321, 'Mekatronik', 'MEP1', 'G', NULL, 'MTE002', 'Matemati', 62, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '15:00:00', 'B46', NULL, NULL, NULL, 0, 'M.Barış EKMEKYAPAR', 'Zafer BAYRAM', NULL);
INSERT INTO `guz` VALUES (322, 'Mekatronik', 'MEP1', 'G', NULL, 'DAD001', 'Doğru Akım Devre Analizi', 100, 'Öğr.Gör.', 'Harun EKER', '2017-12-28', '13:00:00', 'B18', NULL, NULL, NULL, 0, 'Harun EKER', 'M.Akif KARATAŞER', NULL);
INSERT INTO `guz` VALUES (323, 'Mekatronik', 'MEP1', 'G', NULL, 'MEP102', 'Analog Elektroni', 91, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '15:00:00', 'A23', NULL, NULL, NULL, 0, 'Ahmet AKBAY', 'Aysel İÇÖZ', NULL);
INSERT INTO `guz` VALUES (324, 'Mekatronik', 'MEP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'B42', NULL, NULL, NULL, 0, 'H.İbrahim UZ', NULL, NULL);
INSERT INTO `guz` VALUES (325, 'Mekatronik', 'MEP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B46', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (326, 'Mekatronik', 'MEP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '12:30:00', 'B47', NULL, NULL, NULL, 0, 'Nurtekin CURA', NULL, NULL);
INSERT INTO `guz` VALUES (327, 'Mekatronik', 'MEP1', 'G', NULL, 'MEP103', 'Mekatroniğin Temelleri', 74, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-02', '14:00:00', 'A23', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', 'Duygu HÜYÜK', NULL);
INSERT INTO `guz` VALUES (328, 'Mekatronik', 'MEP1', 'G', NULL, 'MEP104', 'Teknik ve Meslek Resm', 107, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-29', '14:00:00', 'A36', NULL, NULL, NULL, 0, 'Yunus GÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (329, 'Mekatronik', 'MEP3', 'G', NULL, 'MEP301', 'Bilgisayarda Programlam', 74, 'Öğr.Gör.', 'Ersoy MEVSİM', '2017-12-27', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', 'Ersoy MEVSİM', NULL);
INSERT INTO `guz` VALUES (330, 'Mekatronik', 'MEP3', 'G', NULL, 'MEP302', 'Bilgisayar Destekli Takım Tezgahları', 73, 'S.Ö.E.', 'Özcan ÖZGENÇ', '2017-12-25', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Özcan ÖZGENÇ', 'Nazan ÖZCAN', NULL);
INSERT INTO `guz` VALUES (331, 'Mekatronik', 'MEP3', 'G', NULL, 'MEP303', 'Proses Kontro', 58, 'Öğr.Gör.', 'Duygu HÜYÜK', '2017-12-28', '10:00:00', 'A11', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (332, 'Mekatronik', 'MEP3', 'G', NULL, 'ENR003', 'Endüstriyel Robotlar', 58, 'Öğr.Gör.', 'Duygu HÜYÜK', '2018-01-04', '15:00:00', 'A11', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (333, 'Mekatronik', 'MEP3', 'IO', NULL, 'MEP305', 'Bilgisayar Destekli Elektronik Devre Tasarımı', 59, 'Öğr.Gör.Dr.', 'Figan DALMIŞ', '2018-01-03', '11:00:00', 'A11', NULL, NULL, NULL, 0, 'Figan DALMIŞ', NULL, NULL);
INSERT INTO `guz` VALUES (334, 'Mekatronik', 'MEP3', 'G', NULL, 'HPN002', 'Hidrolik Pnömatik', 66, 'Yrd.Doç.', 'Atila BABACAN', '2017-12-26', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Atila BABACAN', NULL, NULL);
INSERT INTO `guz` VALUES (335, 'Mekatronik', 'MEP3', 'G', NULL, 'KGS005', 'Kalite Güvencesi ve Standartları', 43, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '09:00:00', 'A33', NULL, NULL, NULL, 0, 'Harun EKER', NULL, NULL);
INSERT INTO `guz` VALUES (336, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'BDÇ105', 'Bilgisayar Destekli Çizim I', 20, 'Öğr.Gör.Dr.', 'Bahadır ALTÜRK', '2017-12-29', '17:00:00', 'B48', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (337, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'MDP101Masif', 'Mobily', 19, 'Öğr.Gör.', 'Emre TEKİN', '2017-12-28', '17:00:00', 'A31', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (338, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'MMT107MeslekiMatematik', '', 0, 'Öğr.Gör.', 'Fulya ÖZDEMİR', '2017-12-25', '18:30:00', 'b42', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (339, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'MDP102Mobilya', 'İmalatında Temel İşlemler', 15, 'Öğr.Gör.', 'Emre TEKİN', '2018-01-03', '17:00:00', 'B42', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (340, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'TKR002', 'Teknik Resi', 0, 'Yrd.Doç.', 'Erdal KILIÇ', '2018-01-04', '17:00:00', 'a36', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (341, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '17:30:00', 'b42', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (342, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Turay YAYLA', '2017-12-26', '17:30:00', 'a11', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (343, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Güray KARADUMAN', '2017-12-27', '17:30:00', 'b47', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (344, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'MDP103', 'Ağaç İşleme Makineleri', 26, 'Öğr.Gör.', 'Emre TEKİN', '2018-01-05', '17:00:00', 'A23', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (345, 'Mobilya Dekorasyon', 'MDP1', 'IO', NULL, 'MDP105', 'Ergonom', 24, 'Öğr.Gör.Dr.', 'Özlem Bozkurt', '2018-01-02', '17:00:00', 'B42', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (346, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'BDÜ103', 'Bilgisayar Destekli Üretim', 30, 'Öğr.Gör.Dr.', 'Bahadır ALTÜRK', '2017-12-28', '19:00:00', 'B47', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (347, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'MDP301Mekan', 'Donatı II', 37, 'Öğr.Gör.Dr.', 'Özlem Bozkurt', '2017-12-26', '18:30:00', 'B70', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (348, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'MRS102Meslek', 'Resim I', 33, 'Öğr.Gör.Dr.', 'Özlem Bozkurt', '2017-12-27', '18:30:00', 'A36', NULL, NULL, NULL, 0, 'Özlem Bozkurt', NULL, NULL);
INSERT INTO `guz` VALUES (349, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'MDP302', 'Üstyüzey İşlemleri', 34, 'Öğr.Gör.Dr.', 'Bahadır ALTÜRK', '2018-01-03', '19:00:00', 'A33', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (350, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'MDP305', 'Döşeme Yapımı', 38, 'Öğr.Gör.Dr.', 'Bahadır ALTÜRK', '2018-01-02', '19:00:00', 'B70', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (351, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'MDP303', 'Ahşap Süsleme Teknikleri I', 29, 'Öğr.Gör.', 'Emre TEKİN', '2017-12-29', '18:00:00', 'A23', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (352, 'Mobilya Dekorasyon', 'MDP3', 'IO', NULL, 'SAT004', 'Sistem Analizi ve Tasarımı', 19, 'Öğr.Gör.', 'Emre TEKİN', '2018-01-04', '19:00:00', 'A23', NULL, NULL, NULL, 0, 'Emre TEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (353, 'Otomotiv', 'OTP1', 'IO', NULL, 'OTP101', 'Motor Teknolojis', 66, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-28', '17:00:00', 'B42', NULL, NULL, NULL, 0, 'Erdal KILIÇ', 'Gürcan UZAL', NULL);
INSERT INTO `guz` VALUES (354, 'Otomotiv', 'OTP1', 'IO', NULL, 'OTP102', 'Otomotiv Elektriği', 78, 'Yrd.Doç.Dr.', 'Ertuğrul KARAKULAK', '2018-01-02', '17:00:00', 'B62', NULL, NULL, NULL, 0, 'Ertuğrul KARAKULAK', 'Erdal KILIÇ', NULL);
INSERT INTO `guz` VALUES (355, 'Otomotiv', 'OTP1', 'G', NULL, 'MRS001', 'Meslek Resi', 56, 'Yrd.Doç.Dr.', 'Erdal KILIÇ', '2018-01-04', '17:00:00', 'A36', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (356, 'Otomotiv', 'OTP1', 'IO', NULL, 'MMT109', 'Mesleki Matematik', 0, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-25', '18:30:00', 'b47', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (357, 'Otomotiv', 'OTP1', 'IO', NULL, 'FİZ003', 'Fizik', 0, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '17:00:00', 'A12', NULL, NULL, NULL, 0, 'Duygu HÜYÜK', NULL, NULL);
INSERT INTO `guz` VALUES (358, 'Otomotiv', 'OTP1', 'IO', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '17:30:00', 'a12', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (359, 'Otomotiv', 'OTP1', 'IO', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Levent TANER', '2017-12-26', '17:30:00', 'a32', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (360, 'Otomotiv', 'OTP1', 'IO', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '17:30:00', 'a12', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (361, 'Otomotiv', 'OTP1', 'IO', NULL, 'ÖÇT003', 'Ölçme Tekniği', 0, 'Öğr.Gör.Dr.', 'Sinan CENGİZ', '2017-12-29', '17:00:00', 'A31', NULL, NULL, NULL, 0, 'Mustafa TEMEL', NULL, NULL);
INSERT INTO `guz` VALUES (362, 'Otomotiv', 'OTP3', 'IO', NULL, 'OTP301', 'Hareket Kontrol Sistemler', 53, 'Öğr.Gör.', 'Mehmet CİVELEK', '2018-01-02', '19:00:00', 'B18', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (363, 'Otomotiv', 'OTP3', 'IO', NULL, 'OTP302', 'Güç Aktarma Organları', 77, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-26', '18:30:00', 'B46', NULL, NULL, NULL, 0, 'Erdal KILIÇ', 'Aytekin ERDEM', NULL);
INSERT INTO `guz` VALUES (364, 'Otomotiv', 'OTP3', 'IO', NULL, 'SAT005', 'Sistem Analizi ve Tasarım', 51, 'Öğr.Gör.', 'Mehmet CİVELEK', '2017-12-25', '19:30:00', 'B70', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (365, 'Otomotiv', 'OTP3', 'IO', NULL, 'OTP303', 'Makine Elemanları', 0, 'Öğr.Gör.', 'Hakan MUTLU', '2017-12-27', '19:30:00', 'A32', NULL, NULL, NULL, 0, 'Hakan MUTLU', NULL, NULL);
INSERT INTO `guz` VALUES (366, 'Otomotiv', 'OTP3', 'IO', NULL, 'OTP304', 'Emisyon Kontrol Sistemler', 54, 'Öğr.Gör.', 'Mehmet CİVELEK', '2017-12-28', '19:00:00', 'A12', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (367, 'Otomotiv', 'OTP3', 'IO', NULL, 'BDÇ005', 'Bilgisayar Destekli Çizim', 67, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2018-01-03', '19:00:00', 'B46', NULL, NULL, NULL, 0, 'Harun EKER', 'Huzur DEVECİ', NULL);
INSERT INTO `guz` VALUES (368, 'Otomotiv', 'OTP3', 'IO', NULL, 'İŞY107', 'İşletme Yönetimi I', 0, 'Öğr.Gör.', 'Cevdet ARITAŞI', '2018-01-05', '19:00:00', 'A12', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (369, 'Seracılık', 'SRP1', 'G', NULL, 'SRP102', 'Genel Seracılık', 17, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2017-12-28', '13:00:00', 'B62', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (370, 'Seracılık', 'SRP1', 'G', NULL, 'SRP101', 'Uygulamalı Seracılık I', 15, 'Öğr.Gör.Dr.', 'Funda ÖZDÜVEN', '2018-01-05', '14:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ÖZDÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (371, 'Seracılık', 'SRP1', 'G', NULL, 'SRP103', 'Bitki Ekolojis', 16, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2017-12-29', '14:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (372, 'Seracılık', 'SRP1', 'G', NULL, 'SRP104', 'Bahçe Bitkileri Temel Bilimleri', 18, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2018-01-04', '13:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (373, 'Seracılık', 'SRP1', 'G', NULL, 'MTE004', 'Matemati', 13, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '14:00:00', 'A31', NULL, NULL, NULL, 0, 'Çetin YAĞCILAR', NULL, NULL);
INSERT INTO `guz` VALUES (374, 'Seracılık', 'SRP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'a23', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (375, 'Seracılık', 'SRP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'Okt.', 'Levent TANER', '2017-12-26', '12:30:00', 'A49', NULL, NULL, NULL, 0, 'Mücella CİHAN', NULL, NULL);
INSERT INTO `guz` VALUES (376, 'Seracılık', 'SRP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'Okt.', 'Aysun ERTEKİN', '2017-12-27', '12:30:00', 'A49', NULL, NULL, NULL, 0, 'Fahriye Kuloğlu AKPINAR', NULL, NULL);
INSERT INTO `guz` VALUES (377, 'Seracılık', 'SRP1', 'G', NULL, 'SRP105', 'Tarımsal Meteoroloji', 18, 'Öğr.Gör.Dr.', 'Elif YÜKSEL TÜRKBOYLARI', '2018-01-03', '13:00:00', 'B41', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', NULL, NULL);
INSERT INTO `guz` VALUES (378, 'Seracılık', 'SRP1', 'G', NULL, 'SRP106', 'Kimy', 18, 'Yrd.Doç.', 'Serap KAYIŞOĞLU', '2018-01-02', '13:00:00', 'A49', NULL, NULL, NULL, 0, 'Serap KAYIŞOĞLU', NULL, NULL);
INSERT INTO `guz` VALUES (379, 'Seracılık', 'SRP3', 'G', NULL, 'SRP302', 'Örtü Altı Sebze Yetiştiriciliği I', 21, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2017-12-27', '10:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (380, 'Seracılık', 'SRP3', 'G', NULL, 'SRP301', 'Uygulamalı Seracılık III', 18, 'Öğr.Gör.Dr.', 'Elif YÜKSEL TÜRKBOYLARI', '2017-12-26', '10:00:00', 'B63', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', NULL, NULL);
INSERT INTO `guz` VALUES (381, 'Seracılık', 'SRP3', 'G', NULL, 'SRP304', 'Bitki Fizyolojis', 17, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2018-01-02', '10:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (382, 'Seracılık', 'SRP3', 'G', NULL, 'SRP305', 'Sera Bitkileri Beslenme Bozuklukları', 18, 'Doç.Dr.', 'Funda ERYILMAZ AÇIKGÖZ', '2018-01-03', '10:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (383, 'Seracılık', 'SRP3', 'G', NULL, 'SRP306', 'Sera Bitki Hastalıkları', 19, 'Öğr.Gör.Dr.', 'Funda ÖZDÜVEN', '2017-12-28', '10:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ÖZDÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (384, 'Seracılık', 'SRP3', 'G', NULL, 'SRP303', 'Süs Bitkileri Yetiştiriciliği I', 22, 'Öğr.Gör.Dr.', 'Elif YÜKSEL TÜRKBOYLARI', '2017-12-25', '10:00:00', 'B63', NULL, NULL, NULL, 0, 'Elif YÜKSEL TÜRKBOYLARI', NULL, NULL);
INSERT INTO `guz` VALUES (385, 'Seracılık', 'SRP3', 'G', NULL, 'SRP307', 'Sera Bitki Zararlıları', 20, 'Öğr.Gör.Dr.', 'Funda ÖZDÜVEN', '2017-12-29', '10:00:00', 'B41', NULL, NULL, NULL, 0, 'Funda ÖZDÜVEN', NULL, NULL);
INSERT INTO `guz` VALUES (386, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'MTE001', 'Matemati', 35, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '14:00:00', 'A33', NULL, NULL, NULL, 0, 'Dilber YILDIZ', NULL, NULL);
INSERT INTO `guz` VALUES (387, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'TBİ002', 'Teknolojinin Bilimsel İlkeleri', 72, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '15:00:00', 'A12', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', 'Fulya ÖZDEMİR', NULL);
INSERT INTO `guz` VALUES (388, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'TMP101', 'Tarımsal Mekanizasyon', 30, 'Öğr.Gör.', 'Mehmet CİVELEK', '2018-01-05', '14:00:00', 'B47', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (389, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'TMP102', 'Toprak Bilgisi Ve Bitki Yetiştirciliği', 35, 'Doç.Dr.', 'Funda Eryılmaz Açıkgöz', '2018-01-02', '14:00:00', 'B47', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (390, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 12, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'b18', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (391, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 27, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B63', NULL, NULL, NULL, 0, 'Aysun ERTEKİN', NULL, NULL);
INSERT INTO `guz` VALUES (392, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 23, 'Okt.', 'Nurtekin CURA', '2017-12-27', '17:30:00', 'A12', NULL, NULL, NULL, 0, 'Nurtekin CURA', NULL, NULL);
INSERT INTO `guz` VALUES (393, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'BİT101', 'Bilgi ve İletişim Teknolojileri', 17, 'Yrd.Doç.', 'Erdal KILIÇ', '2018-01-04', '14:00:00', 'B47', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (394, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'TMP103', 'Ölçme Bilgisi', 38, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-28', '14:00:00', 'B47', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (395, 'Tarım Makineleri', 'TMP1', 'G', NULL, 'HPS001', 'Hidrolik ve Pinomatik Sistemle', 48, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-29', '15:00:00', 'B42', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (396, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'BDT002', 'Bilgisayar Destekli Tasarım', 51, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-25', '10:00:00', 'A12', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (397, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP301', 'Tarımsal Elektirifikasyon', 49, 'Öğr.Gör.', 'Mehmet CİVELEK', '2017-12-26', '10:00:00', 'B18', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (398, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP302', 'Hasat Öncesi Tarım Alet ve Makineleri', 46, 'Öğr.Gör.', 'Mehmet CİVELEK', '2017-12-28', '10:00:00', 'B42', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (399, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP303', 'Termik Motorla', 46, 'Yrd.Doç.', 'Erdal KILIÇ', '2017-12-27', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Erdal KILIÇ', NULL, NULL);
INSERT INTO `guz` VALUES (400, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP304', 'Sulama Makineler', 43, 'Öğr.Gör.', 'Mehmet CİVELEK', '2018-01-02', '10:00:00', 'B18', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (401, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP305', 'Mekanik Teknolojis', 31, 'Öğr.Gör.', 'Mehmet CİVELEK', '2018-01-03', '10:00:00', 'B42', NULL, NULL, NULL, 0, 'Mehmet CİVELEK', NULL, NULL);
INSERT INTO `guz` VALUES (402, 'Tarım Makineleri', 'TMP3', 'G', NULL, 'TMP306', 'Organik Tarım', 51, 'Öğr.Gör', 'Ömer Durmaz', '2017-12-29', '09:00:00', 'B46', NULL, NULL, NULL, 0, 'Funda ERYILMAZ AÇIKGÖZ', NULL, NULL);
INSERT INTO `guz` VALUES (403, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'MTE001', 'Matemati', 56, 'Öğr.Gör.', 'H.İbrahim UZ', '2017-12-25', '14:00:00', 'A32', NULL, NULL, NULL, 0, 'M.Akif KARATAŞER', NULL, NULL);
INSERT INTO `guz` VALUES (404, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'FİZ001', 'Fizik', 99, 'Öğr.Gör.', 'Harun EKER', '2018-01-03', '15:00:00', 'A32', NULL, NULL, NULL, 0, 'Zafer BAYRAM', 'Dilşat UNAKITAN', NULL);
INSERT INTO `guz` VALUES (405, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'TTP101', 'Doğal Lifler', 62, 'Öğr.Gör.', 'Arzu GÖNÜLOL', '2018-01-02', '14:00:00', 'A32', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', 'Arzu GÖNÜLOL', NULL);
INSERT INTO `guz` VALUES (406, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'TTP102', 'İplik Teknolojisi', 54, 'Öğr.Gör.', 'Yasemin ÇİFTÇİ ŞENER', '2017-12-28', '15:00:00', 'B46', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', NULL, NULL);
INSERT INTO `guz` VALUES (407, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'TTP103', 'Dokuma Teknolojis', 40, 'Öğr.Gör.', 'Yasemin ÇİFTÇİ ŞENER', '2018-01-04', '13:00:00', 'A26', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', NULL, NULL);
INSERT INTO `guz` VALUES (408, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 14, 'Okt.', 'Turay YAYLA', '2017-12-26', '12:30:00', 'B18', NULL, NULL, NULL, 0, 'Fikret YIKILMAZ', NULL, NULL);
INSERT INTO `guz` VALUES (409, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 23, 'Okt.', 'Fahriye Kuloğlu AKPINAR', '2017-12-25', '12:30:00', 'B65', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (410, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 30, 'Okt.', 'Nurtekin CURA', '2017-12-27', '17:30:00', 'a12', NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (411, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'BİT007', 'Bilgi ve İletişim Teknolojileri', 52, 'Öğr.Gör.Dr.', 'Emre TAHTABİÇEN', '2018-01-03', '13:00:00', 'A11', NULL, NULL, NULL, 0, 'Erhan KINALI', NULL, NULL);
INSERT INTO `guz` VALUES (412, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'KGS002', 'Kalite Güvence Standartları', 23, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '09:00:00', 'A26', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (413, 'Tekstil Teknolojisi', 'TTP1', 'G', NULL, 'YBS101', 'Yaşam Becerileri ve Sosyal Etkinlik', 21, 'Okt.', 'Tekin ÖZTÜRK', '2017-12-29', '10:00:00', 'A26', NULL, NULL, NULL, 0, 'Tekin ÖZTÜRK', NULL, NULL);
INSERT INTO `guz` VALUES (414, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP302', 'Tekstil Kimyası', 63, 'Öğr.Gör.', 'Şennur ASMA DELEN', '2017-12-26', '14:00:00', 'A11', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', NULL, NULL);
INSERT INTO `guz` VALUES (415, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP305', 'Proteinin ve Selülozun Ön Terbiyesi', 86, 'Öğr.Gör.', 'Arzu GÖNÜLOL', '2017-12-25', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Emre TEKİN', 'Arzu GÖNÜLOL', NULL);
INSERT INTO `guz` VALUES (416, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP303', 'Proteinin ve Selülozün Boyanması', 83, 'Doc.', 'Kenan İmirzalıoğlu', '2017-12-28', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Mücella CİHAN', NULL);
INSERT INTO `guz` VALUES (417, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP304', 'Makinelerle Terbiye İşlemleri', 82, 'Öğr.Gör.', 'Şennur ASMA DELEN', '2018-01-02', '10:00:00', 'B62', NULL, NULL, NULL, 0, 'Şennur ASMA DELEN', 'Duygu HÜYÜK', NULL);
INSERT INTO `guz` VALUES (418, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP301', 'Terbiye İşletme Uygulaması I', 50, 'Öğr.Gör.', 'Yasemin ÇİFTÇİ ŞENER', '2017-12-27', '10:00:00', 'B18', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', NULL, NULL);
INSERT INTO `guz` VALUES (419, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP306', 'Kumaş Yapı Testleri', 69, 'Öğr.Gör.', 'Yasemin ÇİFTÇİ ŞENER', '2018-01-04', '10:00:00', 'B46', NULL, NULL, NULL, 0, 'Yasemin ÇİFTÇİ ŞENER', 'Mehmet CİVELEK', NULL);
INSERT INTO `guz` VALUES (420, 'Tekstil Teknolojisi', 'TTP3', 'G', NULL, 'TTP307', 'Tekstil Yardımcı Maddeleri', 85, 'Öğr.Gör.', 'Arzu GÖNÜLOL', '2017-12-29', '14:00:00', 'B18', NULL, NULL, NULL, 0, 'Serkan TUĞ', 'Arzu GÖNÜLOL', NULL);
INSERT INTO `guz` VALUES (421, 'Yapı Denetim', 'YDP1', 'G', NULL, 'MAT105', 'Matematik', 49, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-25', '14:00:00', 'B18', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (422, 'Yapı Denetim', 'YDP1', 'G', NULL, 'TBİ002', 'Teknolojinin Bilimsel İlkeleri', 119, 'Doç.Dr.', 'Serap AKDEMİR', '2017-12-29', '16:00:00', 'A11', NULL, NULL, NULL, 0, 'Doc AYKUT', 'Sevilay GÜL', NULL);
INSERT INTO `guz` VALUES (423, 'Yapı Denetim', 'YDP1', 'G', NULL, 'YDP101', 'Yapı Statiği I', 93, 'Öğr.Gör.', 'Mustafa TEMEL', '2019-04-15', '09:00:00', 'a54', NULL, NULL, NULL, 20, 'Ahmet BAL', 'Fahriye Kuloğlu AKPINAR', NULL);
INSERT INTO `guz` VALUES (424, 'Yapı Denetim', 'YDP1', 'G', NULL, 'YDP103', 'Malzeme Bilimi ve Yapı Malzemesi', 88, 'Öğr.Gör.', 'Mustafa TEMEL', '2017-12-28', '13:00:00', 'A23', NULL, NULL, NULL, 0, 'Ahmet BAL', 'M.Barış EKMEKYAPAR', NULL);
INSERT INTO `guz` VALUES (425, 'Yapı Denetim', 'YDP1', 'G', NULL, 'TDİ101', 'Türk Dili I', 0, 'Okt.Dr.', 'Fikret YIKILMAZ', '2017-12-25', '12:30:00', 'A12', NULL, NULL, NULL, 0, 'Doc AYKUT', NULL, NULL);
INSERT INTO `guz` VALUES (426, 'Yapı Denetim', 'YDP1', 'G', NULL, 'ATİ101', 'Atatürk İlkeleri ve İnkilap Tarihi I', 0, 'asd', 'ömer', '2017-12-26', '12:30:00', 'A12', NULL, NULL, NULL, 0, 'Hatice ŞİMŞEK', NULL, NULL);
INSERT INTO `guz` VALUES (427, 'Yapı Denetim', 'YDP1', 'G', NULL, 'YDİ101', 'Yabancı Dil I', 0, 'asdasd', 'ömer', '2017-12-27', '12:30:00', 'A12', NULL, NULL, NULL, 0, 'Sinan CENGİZ', NULL, NULL);
INSERT INTO `guz` VALUES (428, 'Yapı Denetim', 'YDP1', 'G', NULL, 'BİT003', 'Bilgi ve İletişim Teknolojileri', 49, 'Doc.', 'Kenan İmirzalıoğlu', '2019-04-12', '09:00:00', 'A12', NULL, NULL, NULL, 0, 'Zafer BAYRAM', NULL, NULL);
INSERT INTO `guz` VALUES (429, 'Yapı Denetim', 'YDP1', 'G', NULL, 'TRK103', 'Teknik Resim', 104, 'Öğr.Gör.', 'Yunus GÜVEN', '2017-12-27', '09:00:00', 'A36', NULL, NULL, NULL, 0, 'asd ömer', NULL, NULL);
INSERT INTO `guz` VALUES (430, 'Yapı Denetim', 'YDP1', 'G', NULL, 'YDP102', 'Yapı Teknolojisi I', 62, 'Öğr.Gör.', 'Mustafa TEMEL', '2019-04-16', '09:00:00', 'A11', NULL, NULL, NULL, 0, 'asd ömer', NULL, NULL);
INSERT INTO `guz` VALUES (431, 'Yapı Denetim', 'YDP3', 'G', NULL, 'BDT101', 'Bilgisayar Destekli Tasarım I', 45, 'Öğr.Gör.Dr.', 'Huzur DEVECİ', '2018-01-04', '09:00:00', 'B46', NULL, NULL, NULL, 0, 'Huzur DEVECİ', NULL, NULL);
INSERT INTO `guz` VALUES (432, 'Yapı Denetim', 'YDP3', 'G', NULL, 'YDP301', 'Betonarme Yapılar', 0, 'Öğr.Gör.', 'M.Barış EKMEKYAPAR', '2017-12-29', '10:00:00', 'A23', NULL, NULL, NULL, 0, 'Bahadır ALTÜRK', 'M.Barış EKMEKYAPAR', NULL);
INSERT INTO `guz` VALUES (433, 'Yapı Denetim', 'YDP3', 'G', NULL, 'YDP302', 'Çelik Yapılar', 0, 'Öğr.Gör.', 'Ahmet BAL', '2018-01-02', '09:00:00', 'A26', NULL, NULL, NULL, 0, 'asdasd ömer', NULL, NULL);
INSERT INTO `guz` VALUES (434, 'Yapı Denetim', 'YDP3', 'IO', NULL, 'YDP303', 'Metraj ve Keşif İşleri', 40, 'asdasd', 'ömer', '2019-04-12', '09:00:00', 'B46', 'a34', NULL, NULL, 40, 'Öğr.Gör. Mustafa TEMEL', 'Huzur DEVECİ', NULL);
INSERT INTO `guz` VALUES (435, 'Yapı Denetim', 'YDP3', 'IO', NULL, 'YDP304', 'Zemin Mekaniği', 45, 'asdasd', 'ömer', '2019-04-12', '09:00:00', 'a25', NULL, NULL, NULL, 45, 'Doc AYKUT', NULL, NULL);
INSERT INTO `guz` VALUES (436, 'Yapı Denetim', 'YDP3', 'G', NULL, 'YDP305', 'Yapı Projesi Uygulamaları', 40, 'Öğr.Gör', 'Ömer Durmaz', '2019-04-12', '09:00:00', 'a54', 'a41', NULL, NULL, 40, 'asd ömer', 'Mehmet CİVELEK', 'asdasd ömer');
INSERT INTO `guz` VALUES (437, 'Yapı Denetim', 'YDP3', 'G', NULL, 'YDP306', 'Büro ve Şantiye Organizasyonu', 65, 'Öğr.Gör.', 'Mustafa TEMEL', '2019-04-17', '14:56:00', NULL, NULL, NULL, NULL, 0, 'Öğr.Gör Ömer Durmaz', 'asdasd ömer', 'Doc. Kenan İmirzalıoğlu');
INSERT INTO `guz` VALUES (438, 'Bilgisayar Programcılığı', 'BPP3', NULL, '1. Dönem', 'MTM10', 'Matematik', 45, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (439, 'Tarım ve Köyişleri', 'TRM101', 'IO', '1. Dönem', 'MTM10', 'Matematik', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL);
INSERT INTO `guz` VALUES (440, 'Elektrik', 'ELK3', 'IO', '1. Dönem', 'MTM10', 'Matematik', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for ogretimelemani
-- ----------------------------
DROP TABLE IF EXISTS `ogretimelemani`;
CREATE TABLE `ogretimelemani`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unvan` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Ad_Soyad` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `eposta` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Kendi_Sinav_Sayisi` int(11) NOT NULL,
  `Gozetmenlik_Sayisi` int(11) NOT NULL,
  `sifre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `yetki` int(255) NULL DEFAULT NULL,
  `bolumu` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 27 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of ogretimelemani
-- ----------------------------
INSERT INTO `ogretimelemani` VALUES (11, 'Yönetici', 'Admin', 'admin@admin.com', 0, 0, 'root', 0, -1);

-- ----------------------------
-- Table structure for sinavderslikleri
-- ----------------------------
DROP TABLE IF EXISTS `sinavderslikleri`;
CREATE TABLE `sinavderslikleri`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `derslik` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sayi` int(11) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of sinavderslikleri
-- ----------------------------
INSERT INTO `sinavderslikleri` VALUES (12, 'a54', 20);
INSERT INTO `sinavderslikleri` VALUES (23, 'a34', 55);
INSERT INTO `sinavderslikleri` VALUES (24, 'a25', 50);
INSERT INTO `sinavderslikleri` VALUES (25, 'a41', 20);
INSERT INTO `sinavderslikleri` VALUES (26, 'a33', 60);
INSERT INTO `sinavderslikleri` VALUES (27, 'a11', 45);

-- ----------------------------
-- Table structure for sinavsaatleri
-- ----------------------------
DROP TABLE IF EXISTS `sinavsaatleri`;
CREATE TABLE `sinavsaatleri`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `saat` time(0) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of sinavsaatleri
-- ----------------------------
INSERT INTO `sinavsaatleri` VALUES (1, '09:00:00');
INSERT INTO `sinavsaatleri` VALUES (2, '14:56:43');
INSERT INTO `sinavsaatleri` VALUES (3, '19:03:00');

-- ----------------------------
-- Table structure for sinavtarihleri
-- ----------------------------
DROP TABLE IF EXISTS `sinavtarihleri`;
CREATE TABLE `sinavtarihleri`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tarih` date NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 537 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of sinavtarihleri
-- ----------------------------
INSERT INTO `sinavtarihleri` VALUES (528, '2019-05-14');
INSERT INTO `sinavtarihleri` VALUES (529, '2019-05-15');
INSERT INTO `sinavtarihleri` VALUES (530, '2019-05-16');
INSERT INTO `sinavtarihleri` VALUES (532, '2019-05-20');
INSERT INTO `sinavtarihleri` VALUES (533, '2019-05-21');
INSERT INTO `sinavtarihleri` VALUES (534, '2019-05-22');
INSERT INTO `sinavtarihleri` VALUES (535, '2019-05-23');
INSERT INTO `sinavtarihleri` VALUES (536, '2019-05-24');

-- ----------------------------
-- Procedure structure for ROWPERROW
-- ----------------------------
DROP PROCEDURE IF EXISTS `ROWPERROW`;
delimiter ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ROWPERROW`()
BEGIN

DECLARE i INT DEFAULT 0;
DECLARE n INT DEFAULT 0;
DECLARE d1 VARCHAR(255);
DECLARE d2 VARCHAR(255);
DECLARE d3 VARCHAR(255);
DECLARE d4 VARCHAR(255);
DECLARE g1 VARCHAR(255);
DECLARE g2 VARCHAR(255);
DECLARE g3 VARCHAR(255);
SELECT MAX(SiraNo) FROM guz INTO n;
SET i=1;
WHILE i<n+1 DO 
	SET g1=(select Gozetmen1 from guz where SiraNo=i);
	IF  g1='' or g1=NULL THEN
		UPDATE guz SET Gozetmen1=NULL,Gozetmen2=NULL,Gozetmen3=NULL where SiraNo=i;
	END IF;
	SET g2=(select Gozetmen2 from guz where SiraNo=i);
	IF  g2='' or g2=NULL THEN
		UPDATE guz SET Gozetmen2=NULL,Gozetmen3=NULL where SiraNo=i;
	END IF;
	SET g3=(select Gozetmen3 from guz where SiraNo=i);
	IF  g3='' or g3=NULL THEN
		UPDATE guz SET Gozetmen3=NULL where SiraNo=i;
	END IF;
	SET d1=(select Derslik1 from guz where SiraNo=i);
	IF  d1='' or d1=NULL THEN
		UPDATE guz SET Derslik1=NULL,Derslik2=NULL,Derslik3=NULL,Derslik4=NULL where SiraNo=i;
	END IF;
	SET d2=(select Derslik2 from guz where SiraNo=i);
	IF  d2='' or d2=NULL THEN
		UPDATE guz SET Derslik2=NULL,Derslik3=NULL,Derslik4=NULL where SiraNo=i;
	END IF;
	SET d3=(select Derslik3 from guz where SiraNo=i);
	IF  d3='' or d3=NULL THEN
		UPDATE guz SET Derslik3=NULL,Derslik4=NULL where SiraNo=i;
	END IF;
		SET d4=(select Derslik4 from guz where SiraNo=i);
	IF  d4='' or d4=NULL THEN
		UPDATE guz SET Derslik4=NULL where SiraNo=i;
	END IF;
  SET i = i + 1;
END WHILE;
End
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
