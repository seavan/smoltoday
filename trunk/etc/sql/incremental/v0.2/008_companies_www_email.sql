set names utf8;

UPDATE companies SET www = email, email = www WHERE www like '%@%';