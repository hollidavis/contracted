CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE companies (
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  name varchar(255) NOT NULL COMMENT 'company name'
)

CREATE TABLE contractors (
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  name varchar(255) NOT NULL COMMENT 'contractor name'
)

CREATE TABLE jobs (
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
  FOREIGN KEY (companyId) REFERENCES companies(id) ON DELETE CASCADE
)