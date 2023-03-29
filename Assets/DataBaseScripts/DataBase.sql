drop database if exists Platformer;
create database if not exists Platformer;

use Platformer;

CREATE TABLE IF NOT EXISTS `Platformer`.`UniqueSkills` (
  `idUniqueSkills` INT NOT NULL,
  `SkillName` VARCHAR(45) NOT NULL,
  `Type` VARCHAR(45) NOT NULL,
  `Power` INT NOT NULL,
  `Description` TEXT NOT NULL,
  `Cooldown` INT NOT NULL,
  PRIMARY KEY (`idUniqueSkills`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Platformer`.`Character` (
  `idCharacter` INT NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `HP` INT NOT NULL,
  `Ranged` TINYINT(1) NOT NULL,
  `MooveSpeed` INT NOT NULL,
  `Damage` INT NOT NULL,
  `AttackSpeed` INT NOT NULL,
  `HeroSkillId` INT NOT NULL,
  PRIMARY KEY (`idCharacter`),
  INDEX `UniqueSkillId_idx` (`HeroSkillId` ASC) VISIBLE,
  CONSTRAINT `UniqueSkillIdHero`
    FOREIGN KEY (`HeroSkillId`)
    REFERENCES `Platformer`.`UniqueSkills` (`idUniqueSkills`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Platformer`.`Monster` (
  `idMonster` INT NOT NULL AUTO_INCREMENT,
  `HP` INT NOT NULL,
  `Ranged` TINYINT(1) NOT NULL,
  `MooveSpeed` INT NOT NULL,
  `Damage` INT NOT NULL,
  `AttackSpeed` INT NOT NULL,
  `MonsterSkillId` INT NULL,
  `SpawnTime` INT NOT NULL,
  `NameMonster` VARCHAR(45) not null,
  PRIMARY KEY (`idMonster`),
  INDEX `UniqueSkillId_idx` (`MonsterSkillId` ASC) VISIBLE,
  CONSTRAINT `UniqueSkillIdMonster`
    FOREIGN KEY (`MonsterSkillId`)
    REFERENCES `Platformer`.`UniqueSkills` (`idUniqueSkills`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `Platformer`.`Player` (
  `idPlayer` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `CharacterId` INT NOT NULL,
  `CharacterLevel` double NOT NULL,
  PRIMARY KEY (`idPlayer`),
  INDEX `CharacterId_idx` (`CharacterId` ASC) VISIBLE,
  CONSTRAINT `CharacterId`
    FOREIGN KEY (`CharacterId`)
    REFERENCES `Platformer`.`Character` (`idCharacter`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



