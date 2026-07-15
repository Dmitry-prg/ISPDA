CREATE DATABASE  IF NOT EXISTS `ispda` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ispda`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: ispda
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `decisions`
--

DROP TABLE IF EXISTS `decisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `decisions` (
  `decision_id` int NOT NULL AUTO_INCREMENT,
  `decision_name` varchar(200) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`decision_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `decisions`
--

LOCK TABLES `decisions` WRITE;
/*!40000 ALTER TABLE `decisions` DISABLE KEYS */;
INSERT INTO `decisions` VALUES (1,'Отклонено',1),(2,'Одобрено',1),(3,'На рассмотрении',1);
/*!40000 ALTER TABLE `decisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_types`
--

DROP TABLE IF EXISTS `document_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_types` (
  `document_type_id` int NOT NULL AUTO_INCREMENT,
  `document_type_name` varchar(200) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`document_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_types`
--

LOCK TABLES `document_types` WRITE;
/*!40000 ALTER TABLE `document_types` DISABLE KEYS */;
INSERT INTO `document_types` VALUES (1,'Протокол об открытии проекта',1),(2,'Приказ о начале проектных работ',1),(3,'Письмо об открытии проекта',1),(4,'Устав проекта',1),(5,'Календарный план',1),(6,'ТЗ - лист',1),(7,'ТЗ',1),(8,'Программа и методика предварительных испытаний - лист',1),(9,'Программа и методика предварительных испытаний',1),(10,'Программа и методика опытной эксплуатации - лист',1),(11,'Программа и методика опытной эксплуатации',1),(12,'План-график опытной эксплуатации',1),(13,'Приказ о создании комиссии по внедрению',1),(14,'Протокол предварительных испытаний',1),(15,'Акт приема-передачи в опытную эксплуатацию',1),(16,'Приказ о начале опытной эксплуатации',1),(17,'Журнал опытной эксплуатации',1),(18,'Акт о завершении опытной эксплуатации',1),(19,'Программа и методика приемочных испытаний - лист',1),(20,'Программа и методика приемочных испытаний',1),(21,'Акт завершения работ',1),(22,'Письмо о завершении проекта',1),(23,'Письмо о направлении договора на ТП',1),(24,'Протокол о закрытии проекта',1);
/*!40000 ALTER TABLE `document_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documents`
--

DROP TABLE IF EXISTS `documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documents` (
  `document_id` int NOT NULL AUTO_INCREMENT,
  `roadmap_item_id` int NOT NULL,
  `document_type_id` int NOT NULL,
  `document_number` varchar(100) NOT NULL,
  `scan_path` varchar(500) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`document_id`),
  KEY `fk_documents_to_projects_idx` (`roadmap_item_id`),
  KEY `fk_documents_to_document_types_idx` (`document_type_id`),
  CONSTRAINT `fk_documents_to_document_types` FOREIGN KEY (`document_type_id`) REFERENCES `document_types` (`document_type_id`),
  CONSTRAINT `fk_documents_to_roadmap_items` FOREIGN KEY (`roadmap_item_id`) REFERENCES `roadmap_items` (`roadmap_item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documents`
--

LOCK TABLES `documents` WRITE;
/*!40000 ALTER TABLE `documents` DISABLE KEYS */;
INSERT INTO `documents` VALUES (1,23,1,'П-001','/scans/2025/protocol_open_001.pdf','2026-01-10 00:00:00',1),(2,24,2,'ПР-002','/scans/2025/order_start_002.pdf','2026-01-12 00:00:00',1),(3,25,3,'ПИ-003','/scans/2025/letter_open_003.pdf','2026-01-15 00:00:00',1),(5,27,5,'КП-005','/scans/2025/schedule_005.pdf','2026-01-22 00:00:00',1),(6,28,6,'ТЗЛ-006','/scans/2025/tz_list_006.pdf','2026-01-25 00:00:00',1),(7,29,7,'ТЗ-007','/scans/2025/tz_007.pdf','2026-01-30 00:00:00',1),(9,31,9,'ПМИП-009','/scans/2025/prelim_test_009.pdf','2026-02-08 00:00:00',1),(10,32,10,'ПМИОЭ-010','/scans/2025/oper_exp_list_010.pdf','2026-02-12 00:00:00',1),(11,33,11,'ПМИОЭ-011','/scans/2025/oper_exp_011.pdf','2026-02-16 00:00:00',1),(12,34,12,'ПГОЭ-012','/scans/2025/oper_schedule_012.pdf','2026-02-18 00:00:00',1),(13,35,13,'ПК-013','/scans/2025/commission_order_013.pdf','2026-02-22 00:00:00',1),(14,36,14,'ППИ-014','/scans/2025/prelim_protocol_014.pdf','2026-02-26 00:00:00',1),(15,37,15,'АПП-015','/scans/2025/act_transfer_015.pdf','2026-03-02 00:00:00',1),(16,38,16,'ПНОЭ-016','/scans/2025/start_oper_order_016.pdf','2026-03-05 00:00:00',1),(17,39,17,'ЖОЭ-017','/scans/2025/oper_log_017.pdf','2026-03-10 00:00:00',1),(18,40,18,'АЗОЭ-018','/scans/2025/oper_complete_018.pdf','2026-03-25 00:00:00',1),(26,23,5,'5555','ееее5555.docx','2026-06-13 00:00:00',1),(27,23,4,'23423','5555.docx','2026-06-26 00:00:00',1);
/*!40000 ALTER TABLE `documents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `heads_organizations`
--

DROP TABLE IF EXISTS `heads_organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `heads_organizations` (
  `head_organization_id` int NOT NULL AUTO_INCREMENT,
  `fio_head` varchar(200) NOT NULL,
  `fio_head_genitive` varchar(200) NOT NULL,
  `fio_head_dative` varchar(200) NOT NULL,
  `short_fio_head` varchar(100) DEFAULT NULL,
  `short_fio_head_reverse` varchar(100) DEFAULT NULL,
  `organization_id` int NOT NULL,
  `position_id` int NOT NULL,
  `position_genitive` varchar(200) DEFAULT NULL,
  `acts_on_the_basis_of` text,
  `period_validity_start` date DEFAULT NULL,
  `period_validity_end` date DEFAULT NULL,
  PRIMARY KEY (`head_organization_id`),
  KEY `fk_heads_organizations_to_organizations_idx` (`organization_id`),
  KEY `fk_heads_organizations_to_positions_idx` (`position_id`),
  CONSTRAINT `fk_heads_organizations_to_organizations` FOREIGN KEY (`organization_id`) REFERENCES `organizations` (`organization_id`),
  CONSTRAINT `fk_heads_organizations_to_positions` FOREIGN KEY (`position_id`) REFERENCES `positions` (`position_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `heads_organizations`
--

LOCK TABLES `heads_organizations` WRITE;
/*!40000 ALTER TABLE `heads_organizations` DISABLE KEYS */;
INSERT INTO `heads_organizations` VALUES (1,'Иванов Алексей Иванович','Иванова Алексея Ивановича','Иванову Алексею Ивановичу','Иванов А.И.',' А.И. Иванов',1,4,'исполняющего обязанности руководителя','Устава','2023-01-15','2028-01-14'),(2,'Петрова Светлана Михайловна','Петровой Светланы Михайловны','Петровой Светлане Михайловне','Петрова С.М.','С.М. Петрова',2,5,'первого заместителя руководителя','Доверенности №123','2022-03-10','2027-03-09'),(3,'Сидоров Дмитрий Викторович','Сидорова Дмитрия Викторовича','Сидорову Дмитрию Викторовичу','Сидоров Д.В.','Д.В. Сидоров ',3,6,'заместителя руководителя','Приказ №45','2021-07-22','2026-07-21'),(4,'Кузнецова Ольга Евгеньевна','Кузнецовой Ольги Евгеньевны','Кузнецовой Ольге Евгеньевне','Кузнецова О.Е.','О.Е. Кузнецова ',4,6,'заместителя руководителя','Устав','2023-05-08','2028-05-07'),(5,'Фёдоров Максим Павлович','Фёдорова Максима Павловича','Фёдорову Максиму Павловичу','Фёдоров М.П.','М.П. Фёдоров ',5,5,'первого заместителя руководителя','Доверенность №789','2020-11-30','2025-11-29'),(6,'Морозова Анна Владимировна','Морозовой Анны Владимировны','Морозовой Анне Владимировне','Морозова А.В.','А.В. Морозова ',6,5,'первого заместителя руководителя','Приказ №15','2022-09-12','2027-09-11'),(7,'Волков Игорь Геннадьевич','Волкова Игоря Геннадьевича','Волкову Игорю Геннадьевичу','Волков И.Г.','И.Г. Волков ',7,5,'первого заместителя руководителя','Устав','2021-12-05','2026-12-04'),(8,'Никитина Людмила Сергеевна','Никитиной Людмилы Сергеевны','Никитиной Людмиле Сергеевне','Никитина Л.С.','Л.С. Никитина ',8,4,'исполняющего обязанности руководителя','Доверенность №202','2023-02-18','2028-02-17'),(9,'Павлов Кирилл Васильевич','Павлова Кирилла Васильевича','Павлову Кириллу Васильевичу','Павлов К.В.','К.В. Павлов ',9,4,'исполняющего обязанности руководителя','Приказ №88','2022-06-25','2027-06-24'),(10,'Голубева Татьяна Николаевна','Голубевой Татьяны Николаевны','Голубевой Татьяне Николаевне','Голубева Т.Н.','Т.Н. Голубева ',10,5,'первого заместителя руководителя','Устав','2021-04-13','2026-04-12'),(11,'Смирнов Андрей Олегович','Смирнова Андрея Олеговича','Смирнову Андрею Олеговичу','Смирнов А.О.','А.О. Смирнов ',11,5,'первого заместителя руководителя','Доверенность №333','2023-08-01','2028-07-31'),(12,'Васильева Елена Дмитриевна','Васильевой Елены Дмитриевны','Васильевой Елене Дмитриевне','Васильева Е.Д.','Е.Д. Васильева ',12,6,'заместителя руководителя','Приказ №77','2022-10-15','2027-10-14'),(13,'Николаев Сергей Александрович','Николаева Сергея Александровича','Николаеву Сергею Александровичу','Николаев С.А.','С.А. Николаев ',13,6,'заместителя руководителя','Устав','2021-05-20','2026-05-19'),(14,'Орлова Мария Константиновна','Орловой Марии Константиновны','Орловой Марии Константиновне','Орлова М.К.','М.К. Орлова ',14,6,'заместителя руководителя','Доверенность №555','2023-03-28','2028-03-27'),(15,'Лебедев Алексей Викторович','Лебедева Алексея Викторовича','Лебедеву Алексею Викторовичу','Лебедев А.В.','А.В. Лебедев',15,6,'заместителя руководителя','Приказ №99','2022-01-09','2027-01-08'),(16,'Волкова Ирина Сергеевна','Волковой Ирины Сергеевны','Волковой Ирине Сергеевне','Волкова И.С.','И.С. Волкова ',16,6,'заместителя руководителя','Устав','2021-08-17','2026-08-16'),(17,'Попов Дмитрий Николаевич','Попова Дмитрия Николаевича','Попову Дмитрию Николаевичу','Попов Д.Н.','Д.Н. Попов ',17,4,'исполняющего обязанности руководителя','Доверенность №666','2023-06-11','2028-06-10'),(18,'Соколова Анна Владимировна','Соколовой Анны Владимировны','Соколовой Анне Владимировне','Соколова А.В.','А.В. Соколова ',18,4,'исполняющего обязанности руководителя','Приказ №22','2022-02-25','2027-02-24'),(19,'Новиков Михаил Игоревич','Новикова Михаила Игоревича','Новикову Михаилу Игоревичу','Новиков М.И.',' М.И. Новиков',19,5,'первого заместителя руководителя','Устав','2021-09-03','2023-04-20'),(20,'Белова Ольга Павловна','Беловой Ольги Павловны','Беловой Ольге Павловне','Белова О.П.',' О.П. Белова',19,5,'первого заместителя руководителя','Доверенность №888','2023-04-20','2028-04-19');
/*!40000 ALTER TABLE `heads_organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `initiative_requests`
--

DROP TABLE IF EXISTS `initiative_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `initiative_requests` (
  `initiative_request_id` int NOT NULL AUTO_INCREMENT,
  `decision_id` int NOT NULL,
  `customer_id` int NOT NULL,
  `initiative_request_details` longtext,
  `created_at` date DEFAULT NULL,
  `approved_at` date DEFAULT NULL,
  PRIMARY KEY (`initiative_request_id`),
  KEY `fk_initiative_requests_decisions_idx` (`decision_id`),
  KEY `fk_initiative_requests_to_organizations_idx` (`customer_id`),
  CONSTRAINT `fk_initiative_requests_to_decisions` FOREIGN KEY (`decision_id`) REFERENCES `decisions` (`decision_id`),
  CONSTRAINT `fk_initiative_requests_to_organizations` FOREIGN KEY (`customer_id`) REFERENCES `organizations` (`organization_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `initiative_requests`
--

LOCK TABLES `initiative_requests` WRITE;
/*!40000 ALTER TABLE `initiative_requests` DISABLE KEYS */;
INSERT INTO `initiative_requests` VALUES (1,2,1,'Заявка на внедрение CRM‑системы для управления взаимоотношениями с клиентами. Требуется ПО типа «1С:CRM» или Salesforce. Необходимые функции: ведение клиентской базы, история взаимодействий, автоматизация продаж, аналитика конверсии, интеграция с email и телефонией. Цель — сократить время обработки заявок на 30 % и повысить лояльность клиентов.','2026-03-25',NULL),(2,3,2,'Запрос на внедрение медицинской информационной системы (МИС) для автоматизации работы больницы. Требуется ПО уровня «Медиалог» или «БАРС.Здравоохранение». Функции: электронная медицинская карта, расписание приёма врачей, учёт медикаментов, отчётность по ОМС, интеграция с ЕГИСЗ. Цель — ускорить обслуживание пациентов и снизить бумажную нагрузку на персонал.','2026-01-16',NULL),(3,1,3,'Инициатива по внедрению платформы для онлайн‑волонтёрства. Требуется веб‑платформа с функциями регистрации волонтёров, учёта часов работы, создания мероприятий, рассылки уведомлений, интеграции с соцсетями. Рассматриваются решения на базе OpenSource (например, VolunteerHub) или кастомная разработка. Цель — упростить координацию волонтёров и повысить прозрачность их работы.','2026-01-17',NULL),(4,2,4,'Запрос на приобретение бухгалтерского ПО для ИП. Требуется программа типа «1С:Бухгалтерия 8» или «Контур.Эльба». Функции: ведение учёта доходов/расходов, формирование отчётности в ФНС и ПФР, расчёт налогов, интеграция с банками, поддержка УСН. Цель — автоматизировать бухгалтерию и снизить риск ошибок.','2026-01-18',NULL),(5,3,5,'Предложение по внедрению ERP‑системы для производственного предприятия. Требуется ПО уровня «1С:ERP Управление предприятием» или SAP S/4HANA. Функции: управление запасами, планирование производства, учёт затрат, контроль качества, интеграция с CRM и бухгалтерией. Цель — оптимизировать производственные процессы и снизить издержки.','2026-01-19',NULL),(6,1,2,'Инициатива по внедрению системы бизнес‑аналитики (BI). Требуется ПО типа Power BI или Tableau. Функции: сбор данных из CRM, ERP, бухгалтерии; визуализация KPI, дашборды, прогнозирование продаж. Цель — повысить точность принятия решений на основе данных.','2026-02-01',NULL),(7,2,6,'Заявка на приобретение ПО для управления проектами. Требуется система типа Jira или Asana. Функции: постановка задач, трекинг времени, диаграммы Ганта, отчёты по загрузке команды, интеграция с Git. Цель — улучшить координацию IT‑проектов и сократить сроки их реализации.','2026-02-02',NULL),(8,3,7,'Предложение по созданию LMS (системы дистанционного обучения). Требуется платформа типа Moodle или TalentLMS. Функции: создание курсов, тестирование, отслеживание прогресса, выдача сертификатов, мобильное приложение. Цель — организовать обучение сотрудников и партнёров.','2026-02-03',NULL),(9,2,8,'Инициатива по внедрению чат‑бота для благотворительного фонда. Требуется разработка чат‑бота на базе Telegram/WhatsApp с функциями: приём пожертвований, ответы на частые вопросы, рассылка отчётов о расходах, интеграция с платёжными системами. Цель — повысить вовлечённость доноров и автоматизировать коммуникации.','2026-02-04',NULL),(10,1,9,'Запрос на миграцию данных в облачное хранилище. Требуется решение типа Яндекс Диск для бизнеса или Google Workspace. Функции: безопасное хранение документов, совместный доступ, версионность файлов, резервное копирование. Цель — обеспечить надёжность данных и удалённый доступ для сотрудников.','2026-02-05',NULL),(11,3,10,'Предложение по автоматизации складского учёта. Требуется ПО типа «МойСклад» или «1С:Управление торговлей». Функции: штрихкодирование, учёт остатков, инвентаризация, интеграция с онлайн‑кассами, отчёты по оборачиваемости. Цель — снизить потери от пересортицы и ускорить комплектацию заказов.','2026-02-10',NULL),(12,2,3,'Заявка на внедрение системы управления контентом (CMS) для сайта компании. Требуется CMS типа WordPress или 1С‑Битрикс. Функции: редактор контента, SEO‑оптимизация, аналитика посещаемости, интеграция с CRM. Цель — обновить корпоративный сайт и улучшить взаимодействие с клиентами.','2026-02-11',NULL),(13,1,11,'Инициатива по внедрению ПО для электронного документооборота (ЭДО). Требуется система типа «Диадок» или «СБИС». Функции: подписание документов электронной подписью, маршрутизация, архивирование, интеграция с бухучётом. Цель — отказаться от бумажного документооборота и ускорить согласование.','2026-02-12',NULL),(14,2,12,'Предложение по закупке ПО для контроля качества продукции. Требуется система MES (Manufacturing Execution System) с функциями: мониторинг параметров производства, фиксация отклонений, отчётность по дефектам, интеграция с ERP. Цель — снизить процент брака на 20 %.','2026-02-13',NULL),(15,3,13,'Заявка на внедрение ПО для экологического мониторинга. Требуется система с функциями: сбор данных с датчиков, визуализация выбросов, прогнозирование превышений норм, генерация отчётов для Росприроднадзора. Рассматриваются специализированные решения для промышленных предприятий. Цель — соблюдать экологические нормативы и избежать штрафов.','2026-02-14',NULL),(16,2,14,'Инициатива по разработке мобильного приложения для партнёров. Требуется приложение с функциями: каталог продукции, онлайн‑заказ, трекинг доставки, чат с менеджером, push‑уведомления. Платформа: iOS и Android. Цель — увеличить продажи через цифровые каналы.','2026-03-01',NULL),(17,1,15,'Запрос на внедрение системы кибербезопасности. Требуется комплекс ПО: антивирус корпоративного уровня (Kaspersky Endpoint Security), межсетевой экран, система обнаружения вторжений (IDS), шифрование данных. Цель — защитить ИТ‑инфраструктуру от кибератак и утечек информации.','2026-03-02','2026-03-06'),(18,3,16,'Предложение по внедрению HRM‑системы. Требуется ПО типа BambooHR или «1С:Зарплата и управление персоналом». Функции: учёт сотрудников, расчёт зарплаты, планирование отпусков, оценка эффективности, адаптация новичков. Цель — автоматизировать HR‑процессы и снизить нагрузку на отдел кадров.','2026-03-03',NULL),(19,2,17,'Заявка на разработку веб‑платформы для онлайн‑продаж. Требуется интернет‑магазин с функциями: каталог товаров, корзина, оплата картами, интеграция с 1С, CRM, служба доставки. Технологии: React + Node.js. Цель — выйти на новые рынки и увеличить выручку.','2026-03-04',NULL),(20,1,18,'Инициатива по закупке ПО для видеоконференций. Требуется решение уровня Zoom Enterprise или Microsoft Teams с функциями: запись встреч, расшифровка речи в текст, виртуальные комнаты, интеграция с календарями. Цель — обеспечить бесперебойную удалённую работу команды.','2026-03-05',NULL),(32,2,8,'Разработать ИС Для Учета товаров на складе','2026-06-10','2026-06-10'),(33,2,8,'склад','2026-06-13','2026-06-13'),(34,2,19,'333','2026-06-17','2026-06-17');
/*!40000 ALTER TABLE `initiative_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizations`
--

DROP TABLE IF EXISTS `organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizations` (
  `organization_id` int NOT NULL AUTO_INCREMENT,
  `stakeholder_type_id` int NOT NULL,
  `full_name` varchar(200) NOT NULL,
  `short_name` varchar(50) DEFAULT NULL,
  `ogrn` varchar(20) DEFAULT NULL,
  `inn` varchar(12) NOT NULL,
  `kpp` varchar(9) NOT NULL,
  `legal_address` text NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`organization_id`),
  KEY `fk_organizations_to_stakeholder_types_idx` (`stakeholder_type_id`),
  CONSTRAINT `fk_organizations_to_stakeholder_types` FOREIGN KEY (`stakeholder_type_id`) REFERENCES `stakeholder_types` (`stakeholder_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizations`
--

LOCK TABLES `organizations` WRITE;
/*!40000 ALTER TABLE `organizations` DISABLE KEYS */;
INSERT INTO `organizations` VALUES (1,2,'Государственное областное бюджетное учреждение \"Центр информационных технологий Мурманской области\"','ГОБУ \"ЦИТ МО\"','1165190061190','5190064320','519001001','г Мурманск, пр. Ленина, д. 75','8-911-3292504','cit@gov-murman.ru',1),(2,1,'Федеральное государственное бюджетное учреждение \"Научно-исследовательский институт перспективных разработок\"','ФГБУ «НИИПР»','1098765432109','7701234567','770101001','г. Санкт‑Петербург, пр. Науки, д. 42','+7 (812) 987‑65‑43','info@techno-progress.ru',1),(3,1,'Благотворительный фонд поддержки образования \"Будущее сегодня\"','БФ «Будущее сегодня»','1157746890124','7725123456','772501001','г. Екатеринбург, ул. Просвещения, д. 8, кв. 12','+7 (343) 555‑12‑34','office@niipr.gov.ru',1),(4,1,'Индивидуальный предприниматель Сидоров Алексей Петрович','ИП Сидоров А.П.','3210987654321','773612345678','772501401','г. Казань, ул. Центральная, д. 25','+7 (843) 234‑56‑78','contact@future-today.org',1),(5,1,'Закрытое акционерное общество «Старый завод»','ЗАО «Старый завод»','1000000000001','7700123450','770001001','г. Нижний Новгород, ул. Заводская, д. 1','+7 (831) 111‑22‑33','sidorov@mail.ru',1),(6,1,'Общество с ограниченной ответственностью «СтройМастер»','ООО «СтройМастер»','1234567890124','7712345679','771201002','г. Москва, ул. Строительная, д. 20, оф. 105','+7 (495) 222‑33‑44','oldfactory@example.com',1),(7,1,'Государственное бюджетное учреждение здравоохранения «Городская клиническая больница № 1»','ГБУЗ «ГКБ № 1»','1098765432110','7701234568','770101002','г. Санкт‑Петербург, ул. Медицинская, д. 5','+7 (812) 888‑77‑66','info@stroymaster.ru',1),(8,1,'Автономная некоммерческая организация «Центр развития молодёжи»','АНО «ЦРМ»','1157746890125','7725123457','772501002','г. Екатеринбург, пр. Молодёжный, д. 10','+7 (343) 444‑55‑66','gkb1@zdrav.spb.ru',1),(9,1,'Индивидуальный предприниматель Иванова Мария Сергеевна','ИП Иванова М.С.','3210987654322','773612345679','772501501','г. Казань, ул. Советская, д. 12','+7 (843) 333‑44‑55','youthcenter@mail.ru',1),(10,1,'Открытое акционерное общество «ЭнергоРесурс»','ОАО «ЭнергоРесурс»','1000000000002','7700123451','770001002','г. Нижний Новгород, пр. Энергетиков, д. 30','+7 (831) 444‑55‑66','ivanovamaria@mail.ru',1),(11,1,'Общество с ограниченной ответственностью «Торговый Дом Восток»','ООО «ТД Восток»','1234567890125','7712345680','771201003','г. Москва, ш. Восточное, д. 100, оф. 205','+7 (495) 555‑66‑77','energy@energoresurs.ru',1),(12,1,'Федеральное казённое учреждение «Исправительная колония № 5»','ФКУ ИК‑5','1098765432111','7701234569','770101003','г. Санкт‑Петербург, ул. Колонийная, д. 7','+7 (812) 777‑88‑99','vostok@tdvostok.ru',1),(13,1,'Региональный общественный фонд помощи животным «Лапа дружбы»','РОФ «Лапа дружбы»','1157746890126','7725123458','772501003','г. Екатеринбург, ул. Зоопарковая, д. 15','+7 (343) 666‑77‑88','ik5@fsin.gov.ru',1),(14,1,'Индивидуальный предприниматель Петров Дмитрий Викторович','ИП Петров Д.В.','3210987654323','773612345680','772501561','г. Казань, пр. Победы, д. 22','+7 (843) 444‑55‑66','paw@lapadrugby.ru',1),(15,1,'Общество с ограниченной ответственностью «Логистик Групп»','ООО «Логистик Групп»','1000000000003','7700123452','770001003','г. Нижний Новгород, ул. Логистическая, д. 50','+7 (831) 555‑66‑77','petrov@mail.ru',1),(16,1,'Общество с ограниченной ответственностью «МедиаПроект»','ООО «МедиаПроект»','1234567890126','7712345681','771201004','г. Москва, пр. Медиа, д. 1, оф. 401','+7 (495) 666‑77‑88','logistics@logisticgroup.ru',1),(17,1,'Муниципальное автономное учреждение «Дворец культуры “Юность”»','МАУ «ДК “Юность”»','1098765432112','7701234570','770101004','г. Санкт‑Петербург, ул. Культурная, д. 3','+7 (812) 666‑55‑44','media@mediaproject.ru',1),(18,1,'Некоммерческая организация «Экологический альянс»','НО «ЭкоАльянс»','1157746890127','7725123459','772501004','г. Екатеринбург, ул. Экологическая, д. 2','+7 (343) 777‑88‑99','dk-yunost@kultura.spb.ru',1),(19,1,'Общество с ограниченной ответственностью «ТехноПрогресс»','ООО «ТехноПрогресс»','1234567890123','7712345678','771201001','г. Москва, ул. Инновационная, д. 15, оф. 301','+7 (495) 123‑45‑67','eco@ecoalliance.ru',1),(21,1,'ГОУП \"Мурманскводоканал\" ','Водоканал','1025100860784','5193600346','519001001','183038, Мурманская область, город Мурманск, ул Дзержинского, д. 9 ','8931411231','office@mvk.ru',1);
/*!40000 ALTER TABLE `organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `position_id` int NOT NULL AUTO_INCREMENT,
  `position_name` varchar(200) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`position_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Ведущий инженер по защите информации',1),(2,'Ведущий аналитик',1),(3,'Начальник отдела разработки информационных систем',1),(4,'Исполняющий обязанности руководителя',1),(5,'Первый заместитель руководителя',1),(6,'Заместитель руководителя',1),(7,'Офис-менеджер',1),(8,'Менеджер по связям с общественностью',1),(9,'Главный бухгалтер',1),(10,'Заместитель главного бухгалтера',1),(11,'Ведущий бухгалтер',1),(12,'Ведущий юрисконсульт',1),(13,'Ведущий специалист по кадрам',1),(14,'Контрактный управляющий',1),(15,'Помощник контрактного управляющего',1),(16,'Специалист по закупкам',1),(17,'Инженер по зданию 1 категории',1),(18,'Начальник сектора аттестации',1),(19,'Инженер 2 категории',1),(20,'Инженер по защите информации 1 категории',1),(21,'Инженер по защите информации 2 категории',1),(22,'Ведущий инженер',1),(23,'Инженер 1 категории',1),(24,'Инженер 2 категории',1),(25,'Ведущий специалист',1),(26,'Аналитик 1 категории',1),(27,'Начальник контакт-центра',1),(28,'Заместитель начальника контакт-центра',1);
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_stages`
--

DROP TABLE IF EXISTS `project_stages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project_stages` (
  `stage_id` int NOT NULL AUTO_INCREMENT,
  `stage_name` varchar(200) NOT NULL,
  `description` text,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`stage_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_stages`
--

LOCK TABLES `project_stages` WRITE;
/*!40000 ALTER TABLE `project_stages` DISABLE KEYS */;
INSERT INTO `project_stages` VALUES (1,'Начало проекта','Утверждается устав проекта, назначается руководитель, определяются цели, границы и ключевые ограничения проекта, формируется реестр заинтересованных сторон.',1),(2,'Изменение проекта ','Регистрируются запросы на изменение, анализируется их влияние на сроки, бюджет и содержание проекта, проводится согласование изменений и вносятся утверждённые корректировки в документацию.',1),(3,'Проектирование','Разрабатываются и согласовываются архитектура системы, спецификации компонентов, модели данных, интерфейсов и алгоритмов, оформляется технический проект и проектная документация.',1),(4,'Разработка','Выполняются программирование и настройка компонентов системы, их интеграция, модульное тестирование, сборка и выпуск рабочих версий в соответствии с утверждёнными проектными решениями.\r\n\r\nВыполняются программирование и настройка компонентов системы, их интеграция, модульное тестирование, сборка и выпуск рабочих версий в соответствии с утверждёнными проектными решениями.\r\nВыполняются программирование и настройка компонентов системы, их интеграция, модульное тестирование, сборка и выпуск рабочих версий в соответствии с утверждёнными проектными решениями.\r\n\r\nВыполняются программирование и настройка компонентов системы, их интеграция, модульное тестирование, сборка и выпуск рабочих версий в соответствии с утверждёнными проектными решениями.',1),(5,'Подготовка к испытаниям','Разрабатывается программа и методики испытаний, подготавливаются тестовые среды, наборы данных и сценарии, формируется приёмочная комиссия и проверяется готовность системы к испытаниям.',1),(6,'Предварительные испытания','Проводится автономная проверка компонентов и подсистем по утверждённой программе, подтверждается корректность реализации функциональных требований и выявляются несоответствия для их устранения.',1),(7,'Опытная эксплуатация','Система запускается в ограниченной среде на реальных данных, проверяется её работоспособность и удобство использования, выявляются скрытые дефекты для последующего устранения перед промышленным запуском.',1),(8,'Закрытие проекта','Завершаются все работы, подписывается итоговый акт сдачи-приёмки, передаётся полный комплект документации заказчику, расформировывается команда проекта и выполняется архивирование материалов.',1),(9,'Лицензирование','Приобретаются и оформляются лицензии на программное обеспечение и иные объекты интеллектуальной собственности, передаются права на их использование заказчику в соответствии с условиями договора.',1),(10,'Приемочные испытания','Выполняется комплексная проверка системы заказчиком на соответствие техническому заданию и контрактным требованиям, по результатам которой принимается решение о приёмке системы в промышленную эксплуатацию.',1),(11,'Нормативно-правовые акты','Анализируются законодательные и отраслевые требования, применимые к создаваемой системе, разрабатываются и утверждаются внутренние нормативные документы, регламентирующие порядок работ и эксплуатации.',1);
/*!40000 ALTER TABLE `project_stages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_teams`
--

DROP TABLE IF EXISTS `project_teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project_teams` (
  `project_team_id` int NOT NULL AUTO_INCREMENT,
  `proejct_id` int NOT NULL,
  `user_id` int NOT NULL,
  `role_in_project` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`project_team_id`),
  KEY `fk_project_teams_to_projects_idx` (`proejct_id`),
  KEY `fk_project_teams_to_users_idx` (`user_id`),
  CONSTRAINT `fk_project_teams_to_projects` FOREIGN KEY (`proejct_id`) REFERENCES `projects` (`project_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_project_teams_to_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_teams`
--

LOCK TABLES `project_teams` WRITE;
/*!40000 ALTER TABLE `project_teams` DISABLE KEYS */;
INSERT INTO `project_teams` VALUES (1,2,1,'Руководитель проекта'),(8,13,5,'Руководитель проекта'),(9,13,10,'Разработчик'),(10,13,4,'Тестировщик'),(11,13,9,'Аналитик'),(12,2,5,'Разработчик'),(13,2,9,'Разработчик'),(14,2,4,'Аналитик'),(15,2,10,'Тестировщик'),(16,23,2,'Руководитель проекта'),(17,3,6,'руководитель проекта'),(18,3,9,'Тестировщик'),(26,3,10,'Разработчик'),(31,4,1,'Руководитель проекта'),(32,8,4,'Руководитель проекта'),(33,25,1,'Руководитель проекта'),(34,5,1,'Руководитель проекта');
/*!40000 ALTER TABLE `project_teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `project_id` int NOT NULL AUTO_INCREMENT,
  `status_id` int NOT NULL,
  `project_number` varchar(100) DEFAULT NULL,
  `project_name` varchar(500) NOT NULL,
  `project_short_name` varchar(200) DEFAULT NULL,
  `initiative_request_id` int NOT NULL,
  `developer_id` int NOT NULL,
  `product_name` varchar(500) DEFAULT NULL,
  `product_name_genitive` varchar(500) DEFAULT NULL,
  `product_name_prepositional` varchar(500) DEFAULT NULL,
  `product_short_name` varchar(200) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `actual_start_date` date DEFAULT NULL,
  `actual_end_date` date DEFAULT NULL,
  `url` varchar(500) DEFAULT NULL,
  `ip` varchar(50) DEFAULT NULL,
  `admin_panel_url` varchar(500) DEFAULT NULL,
  `is_gis` tinyint DEFAULT '0',
  `is_pnd` tinyint DEFAULT '0',
  `is_internal` tinyint DEFAULT '0',
  `notes` text,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`project_id`),
  KEY `fk_projects_to_statuses_idx` (`status_id`),
  KEY `fk_projects_customer_to_users_idx` (`initiative_request_id`),
  KEY `fk_projects_developer_to_organizations_idx` (`developer_id`),
  CONSTRAINT `fk_projects_developer_to_organizations` FOREIGN KEY (`developer_id`) REFERENCES `organizations` (`organization_id`),
  CONSTRAINT `fk_projects_to_initiative_requests` FOREIGN KEY (`initiative_request_id`) REFERENCES `initiative_requests` (`initiative_request_id`),
  CONSTRAINT `fk_projects_to_statuses` FOREIGN KEY (`status_id`) REFERENCES `statuses` (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (2,9,'2','Автоматизация больницы: внедрение МИС','МИС-ГКБ',9,1,'«Медиалог»','«Медиалога»','в «Медиалоге»','Медиалог','2026-02-14','2026-06-16','2026-02-15',NULL,'mis.hospital-spb.ru','10.0.0.25','admin.mis.hospital-spb.ru',0,1,1,'Интеграция с ЕГИСЗ запланирована на этап 2',1),(3,9,'PROJ-003','Платформа онлайн‑волонтёрства для АНО «ЦПМ»','Волонтёр-ЦПМ',12,1,'12','VolunteerHub','VolunteerHub','в VolunteerHub','2026-02-14','2026-05-31','2026-02-17','2026-03-15','volunteer.cp-m.org','172.16.5.100','admin.volunteer.cp-m.org',0,0,0,'Открытый доступ для волонтёров',1),(4,9,'4','Автоматизация бухгалтерии для ИП Сидоров А.П.','Бух-Сидоров',4,1,'«Контур.Эльба»','«Контура.Эльбы»','в «Контуре.Эльбе»','Эльба','2026-06-21','2027-06-29',NULL,NULL,'accountant.sidorov.ru','192.168.2.20','admin.accountant.sidorov.ru',0,0,1,'Настройка под УСН 6 %',1),(5,3,'PROJ-005','Внедрение ERP на производственном предприятии','ERP-Завод',5,1,'«1С:ERP Управление предприятием»','«1С:ERP Управления предприятием»','в «1С:ERP Управлении предприятием»','1С:ERP','2026-03-01','2026-09-30',NULL,NULL,'erp.oldfactory.com','10.10.0.50','admin.erp.oldfactory.com',0,1,1,'Масштабный проект с поэтапным внедрением',1),(6,9,'PROJ-006','BI‑система для аналитики продаж ООО «ТД Альфа»','BI-Альфа',12,1,'Power BI','Power BI','в Power BI','PBI','2026-03-15','2026-05-15','2026-03-20',NULL,'bi.td-alpha.ru','192.168.1.15','admin.bi.td-alpha.ru',0,0,1,'Интеграция с CRM и ERP системами',1),(7,1,'PROJ-007','Система управления проектами для IT‑отдела','Jira-IT',7,1,'Jira','Jira','в Jira','Jira','2026-03-01','2026-04-15','2026-03-05','2026-04-10','jira.stroymaster.ru','192.168.3.30','admin.jira.stroymaster.ru',0,0,1,'Обучение команды проведено',1),(8,3,'PROJ-008','LMS для повышения квалификации сотрудников','LMS-НИУ',8,1,'Moodle','Moodle','в Moodle','Moodle','2026-03-10','2026-06-10','2026-03-25',NULL,'lms.niu.edu.ru','172.20.1.5','admin.lms.niu.edu.ru',0,0,0,'Доступ для студентов и преподавателей',1),(9,2,'PROJ-009','Чат‑бот для благотворительного фонда','Бот-Помощь',9,1,'Telegram Bot API','Telegram Bot API','в Telegram Bot API','Бот-Помощь','2026-03-15','2026-04-15','2026-03-20','2026-04-12','t.me/help_kids_bot','172.20.1.7','admin.disk.bus.kz.com',0,0,0,'Интеграция с CloudPayments',1),(10,1,'PROJ-010','Миграция в облачное хранилище для ИП Козлова А.В.','Облако-Козлова',10,1,'Яндекс Диск для бизнеса','Яндекс Диска для бизнеса','в Яндекс Диске для бизнеса','ЯД-Бизнес','2026-03-05','2026-03-25','2026-03-07','2026-03-22','disk.business.kozlova.ru','172.20.1.12','admin.disk.business.kozlova.ru',0,0,1,'Резервное копирование ежедневно',1),(11,3,'PROJ-011','Автоматизация складского учёта для ООО «Логистик-Сервис»','WMS-Логистик',11,1,'«МойСклад»','«Моего Склада»','в «Моем Складе»','МойСклад','2026-03-20','2026-05-20',NULL,NULL,'wms.logistic-service.ru','10.20.0.100','admin.wms.logistic-service.ru',0,1,1,'Внедрение штрихкодирования',1),(12,2,'PROJ-012','Обновление корпоративного сайта ООО «ТД Альфа»','Сайт-Альфа',12,1,'WordPress','WordPress','в WordPress','WP','2026-03-10','2026-04-30','2026-03-15',NULL,'www.td-alpha.ru','192.168.1.25','admin.td-alpha.ru',0,0,0,'SEO‑оптимизация включена в проект',1),(13,9,'PROJ-013','Внедрение ЭДО для ООО «СтройМастер»','ЭДО-Строй',7,1,'«Диадок»','«Диадока»',' «Диадок»','Диадок','2026-03-15','2026-04-15','2026-03-20','2026-04-14','edo.stroygarant.ru','192.168.4.40','admin.edo.stroygarant.ru',0,0,1,'Обучение сотрудников',1),(14,2,'PROJ-001','Внедрение CRM‑системы для ООО «ТД Альфа»','CRM-Альфа',1,1,'«1С:CRM»','«1С:CRM»','в «1С:CRM»','1С:CRM','2026-02-01','2026-04-30','2026-02-10',NULL,'crm.td-alpha.ru','192.168.1.10','admin.crm.td-alpha.ru/login',0,0,1,'Пилотный проект с интеграцией телефонии',1),(23,9,'5555','Разработка ИС Учёта товаров на складе','Разработка ИС Склад',32,1,'ИС Склад','ИС Склад','ИС Склад','Склад','2026-01-09','2026-06-25',NULL,NULL,'','','',0,0,0,'',1),(25,1,'1414','gdgdgdfg','',34,1,'','','','','2026-06-25','2026-06-25',NULL,NULL,'','','',0,0,0,'',1);
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `required_docs_stage_project`
--

DROP TABLE IF EXISTS `required_docs_stage_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `required_docs_stage_project` (
  `required_docs_stage_project_id` int NOT NULL AUTO_INCREMENT,
  `roadmap_item_id` int NOT NULL,
  `document_type_id` int NOT NULL,
  PRIMARY KEY (`required_docs_stage_project_id`),
  KEY `fk_required_docs_stage_project_to_document_types_idx` (`document_type_id`),
  KEY `fk_required_docs_stage_project_to_roadmap_items_idx` (`roadmap_item_id`),
  CONSTRAINT `fk_required_docs_stage_project_to_document_types` FOREIGN KEY (`document_type_id`) REFERENCES `document_types` (`document_type_id`),
  CONSTRAINT `fk_required_docs_stage_project_to_roadmap_items` FOREIGN KEY (`roadmap_item_id`) REFERENCES `roadmap_items` (`roadmap_item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `required_docs_stage_project`
--

LOCK TABLES `required_docs_stage_project` WRITE;
/*!40000 ALTER TABLE `required_docs_stage_project` DISABLE KEYS */;
INSERT INTO `required_docs_stage_project` VALUES (2,23,4);
/*!40000 ALTER TABLE `required_docs_stage_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roadmap_items`
--

DROP TABLE IF EXISTS `roadmap_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roadmap_items` (
  `roadmap_item_id` int NOT NULL AUTO_INCREMENT,
  `project_id` int NOT NULL,
  `stage_id` int NOT NULL,
  `turn` int DEFAULT NULL,
  `planned_start` date DEFAULT NULL,
  `planned_end` date DEFAULT NULL,
  `actual_start` date DEFAULT NULL,
  `actual_end` date DEFAULT NULL,
  `notes` text,
  PRIMARY KEY (`roadmap_item_id`),
  KEY `fk_roadmap_items_to_projects_idx` (`project_id`),
  KEY `fk_roadmap_items_to_projects_stages_idx` (`stage_id`),
  CONSTRAINT `fk_roadmap_items_to_project_stages` FOREIGN KEY (`stage_id`) REFERENCES `project_stages` (`stage_id`),
  CONSTRAINT `fk_roadmap_items_to_projects` FOREIGN KEY (`project_id`) REFERENCES `projects` (`project_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roadmap_items`
--

LOCK TABLES `roadmap_items` WRITE;
/*!40000 ALTER TABLE `roadmap_items` DISABLE KEYS */;
INSERT INTO `roadmap_items` VALUES (23,2,1,1,'2026-02-14','2026-02-21','2026-02-15','2026-02-23','Сбор требований'),(24,2,2,2,'2026-02-22','2026-03-01','2026-02-23','2026-03-02','Проектирование архитектуры системы'),(25,2,3,3,'2026-03-02','2026-03-15','2026-03-03','2026-03-16','Разработка бэкенда (основные модули)'),(26,2,4,4,'2026-03-16','2026-03-26','2026-03-17','2026-03-26','Разработка API и интеграции'),(27,2,5,5,'2026-03-26','2026-04-09','2026-03-26','2026-04-15','Фронтенд-разработка (основные экраны)'),(28,2,6,6,'2026-04-16','2026-04-29','2026-04-18','2026-05-01','Интеграция фронтенда и бэкенда'),(29,2,7,7,'2026-05-02','2026-05-15','2026-05-03','2026-05-16','Модульное тестирование компонентов'),(30,2,8,8,'2026-05-16','2026-05-30','2026-05-17','2026-06-01','Системное тестирование и отладка'),(31,2,9,9,'2026-06-02','2026-06-08','2026-06-02','2026-06-09','Приёмочное тестирование (UAT)'),(32,2,10,10,'2026-06-09','2026-06-13','2026-06-10','2026-06-14','Подготовка к релизу, документирование'),(33,2,11,11,'2026-06-14','2026-06-15','2026-06-15','2026-06-15','Развёртывание на продакшн, финальные проверки'),(34,3,1,1,'2026-02-14','2026-02-16','2026-02-14','2026-02-15','Анализ требований и формирование ТЗ'),(35,3,2,2,'2026-02-17','2026-02-19','2026-02-18','2026-02-19','Проектирование интерфейса и UX'),(36,3,3,3,'2026-02-20','2026-02-22','2026-02-21','2026-02-23','Прототипирование и согласование макетов'),(37,3,4,4,'2026-02-23','2026-02-25','2026-02-24','2026-02-26','Разработка серверной логики'),(38,3,5,5,'2026-02-26','2026-02-27','2026-02-27','2026-02-28','Реализация клиентской части'),(39,3,6,6,'2026-02-28','2026-03-01','2026-02-28','2026-03-01','Тестирование и исправление ошибок'),(40,3,7,7,NULL,NULL,NULL,NULL,'Подготовка релиза и документации'),(51,6,1,1,'2026-03-15','2026-04-13','2026-03-15','2026-04-13',''),(57,6,5,2,'2026-04-13','2026-04-24','2026-04-13','2026-04-24',''),(61,6,11,3,'2026-04-24','2026-05-02','2026-04-24','2026-05-02',''),(62,6,8,4,'2026-05-02','2026-05-08','2026-05-02','2026-05-15',''),(63,6,9,5,'2026-05-08','2026-05-09','2026-05-08','2026-05-09',''),(65,11,1,1,'2026-03-20','2026-03-27','2026-03-20','2026-03-28',''),(66,11,9,2,'2026-03-28','2026-05-16','2026-05-01','2026-05-01',''),(67,13,1,1,'2026-03-15','2026-03-30',NULL,NULL,'Утверждается устав проекта, назначается руководитель, определяются цели, границы и ключевые ограничения проекта, формируется реестр заинтересованных сторон.'),(73,13,4,2,'2026-03-30','2026-04-03',NULL,NULL,'Выполняются программирование и настройка компонентов системы, их интеграция, модульное тестирование, сборка и выпуск рабочих версий в соответствии с утверждёнными проектными решениями.'),(75,13,8,3,'2026-04-03','2026-04-10',NULL,NULL,'Завершаются все работы, подписывается итоговый акт сдачи-приёмки, передаётся полный комплект документации заказчику, расформировывается команда проекта и выполняется архивирование материалов.'),(76,13,9,4,'2026-04-10','2026-04-15',NULL,NULL,'Приобретаются и оформляются лицензии на программное обеспечение и иные объекты интеллектуальной собственности, передаются права на их использование заказчику в соответствии с условиями договора.'),(77,14,1,1,'2026-02-02','2026-04-09',NULL,NULL,'Утверждается устав проекта, назначается руководитель, определяются цели, границы и ключевые ограничения проекта, формируется реестр заинтересованных сторон.'),(78,14,7,2,'2026-04-09','2026-04-16',NULL,NULL,'Система запускается в ограниченной среде на реальных данных, проверяется её работоспособность и удобство использования, выявляются скрытые дефекты для последующего устранения перед промышленным запуском.'),(79,23,1,1,'2026-01-09','2026-01-16',NULL,NULL,'Утверждается устав проекта, назначается руководитель, определяются цели, границы и ключевые ограничения проекта, формируется реестр заинтересованных сторон.'),(80,23,3,2,'2026-01-17','2026-03-19',NULL,NULL,'Разрабатываются и согласовываются архитектура системы, спецификации компонентов, модели данных, интерфейсов и алгоритмов, оформляется технический проект и проектная документация.'),(81,23,8,3,'2026-04-02','2026-04-16',NULL,NULL,'Завершаются все работы, подписывается итоговый акт сдачи-приёмки, передаётся полный комплект документации заказчику, расформировывается команда проекта и выполняется архивирование материалов.'),(82,3,8,8,'2026-05-16','2026-05-21',NULL,NULL,'Завершаются все работы, подписывается итоговый акт сдачи-приёмки, передаётся полный комплект документации заказчику, расформировывается команда проекта и выполняется архивирование материалов.'),(83,3,9,9,'2026-04-09','2026-05-20',NULL,NULL,'Приобретаются и оформляются лицензии на программное обеспечение и иные объекты интеллектуальной собственности, передаются права на их использование заказчику в соответствии с условиями договора.'),(101,4,1,1,'2026-06-25','2026-08-20',NULL,NULL,'Утверждается устав проекта, назначается руководитель, определяются цели, границы и ключевые ограничения проекта, формируется реестр заинтересованных сторон.'),(102,4,8,2,'2027-06-02','2027-06-27',NULL,NULL,'Завершаются все работы, подписывается итоговый акт сдачи-приёмки, передаётся полный комплект документации заказчику, расформировывается команда проекта и выполняется архивирование материалов.');
/*!40000 ALTER TABLE `roadmap_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Администратор'),(2,'Менеджер'),(3,'Аналитик');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stakeholder_types`
--

DROP TABLE IF EXISTS `stakeholder_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stakeholder_types` (
  `stakeholder_type_id` int NOT NULL,
  `stakeholder_type_name` varchar(200) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`stakeholder_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stakeholder_types`
--

LOCK TABLES `stakeholder_types` WRITE;
/*!40000 ALTER TABLE `stakeholder_types` DISABLE KEYS */;
INSERT INTO `stakeholder_types` VALUES (1,'Заказчик',1),(2,'Разработчик',1);
/*!40000 ALTER TABLE `stakeholder_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuses`
--

DROP TABLE IF EXISTS `statuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statuses` (
  `status_id` int NOT NULL AUTO_INCREMENT,
  `status_name` varchar(200) NOT NULL,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuses`
--

LOCK TABLES `statuses` WRITE;
/*!40000 ALTER TABLE `statuses` DISABLE KEYS */;
INSERT INTO `statuses` VALUES (1,'Черновик',1),(2,'На согласовании',1),(3,'Согласован',1),(4,'Отклонён',1),(5,'На доработке',1),(6,'В архиве',1),(7,'Инициация',1),(8,'Планирование',1),(9,'В работе',1),(10,'Приостановлен',1),(11,'На контроле',1),(12,'Частично завершён',1),(13,'Завершён',1),(14,'Закрыт досрочно',1),(15,'На утверждении результатов',1),(16,'Требует корректировки',1);
/*!40000 ALTER TABLE `statuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `patronymic` varchar(100) DEFAULT NULL,
  `organization_id` int NOT NULL,
  `position_id` int NOT NULL,
  `role_id` int NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `is_active` tinyint DEFAULT '1',
  `is_superuser` tinyint DEFAULT '0',
  `date_create` date DEFAULT NULL,
  `last_login` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `fk_users_to_organizations_idx` (`organization_id`),
  KEY `fk_users_to_positions_idx` (`position_id`),
  KEY `fk_users_to_roles_idx` (`role_id`),
  CONSTRAINT `fk_users_to_organizations` FOREIGN KEY (`organization_id`) REFERENCES `organizations` (`organization_id`),
  CONSTRAINT `fk_users_to_positions` FOREIGN KEY (`position_id`) REFERENCES `positions` (`position_id`),
  CONSTRAINT `fk_users_to_roles` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'1','11','Иванов','Алексей','Иванович',1,2,1,'a.ivanov@company.ru','79161234567',1,1,NULL,NULL),(2,'2','22','Петрова','Светлана','Михайловна',1,2,3,'s.petrova@company.ru','79162345678',1,0,NULL,NULL),(3,'sidorov_dv','hash789','Сидоров','Дмитрий','Викторович',1,1,3,'d.sidorov@company.ru','79163456789',0,0,NULL,NULL),(4,'kuznetsova_oe','hash012','Кузнецова','Ольга','Евгеньевна',1,3,2,'o.kuznetsova@company.ru','79164567890',1,0,NULL,NULL),(5,'fedorov_mp','hash345','Фёдоров','Максим','Павлович',1,2,3,'m.fedorov@company.ru','79165678901',1,0,NULL,NULL),(6,'morozova_av','hash678','Морозова','Анна','Владимировна',1,1,1,'a.morozova@company.ru','79166789012',1,1,NULL,NULL),(7,'volkov_ig','hash901','Волков','Игорь','Геннадьевич',7,1,3,'i.volkov@company.ru','79167890123',0,0,NULL,NULL),(8,'nikitina_ls','hash234','Никитина','Людмила','Сергеевна',8,1,2,'l.nikitina@company.ru','79168901234',1,0,NULL,NULL),(9,'pavlov_kv','hash567','Павлов','Кирилл','Васильевич',9,1,2,'k.pavlov@company.ru','79169012345',1,0,NULL,NULL),(10,'golubeva_tn','hash890','Голубева','Татьяна','Николаевна',10,2,2,'t.golubeva@company.ru','79160123456',1,0,NULL,NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'ispda'
--

--
-- Dumping routines for database 'ispda'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-26  5:35:59
