SELECT countries.name, languages.language, languages.percentage
FROM countries
JOIN languages ON countries.id = languages.country_id
WHERE language = 'Slovene' 
ORDER BY languages.percentage DESC;


SELECT counties.name, COUNT(cities.id) as num_cities
FROM countries
JOIN cities ON countries.id = cities.country_id
GROUP BY countries.id
ORDER BY num_cities DESC;

SELECT cities.name, cities.population
FROM countries
JOIN cities ON countries.id = cities.country_id
WHERE countries.name = 'Mexico' AND cities.population > 500000
ORDER BY cities.population DESC;

SELECT countries.name, languages.language, languages.percentage
FROM countries
JOIN languages ON countries.id = languages.country_id
WHERE percentage > 89
ORDER BY percentage DESC;

SELECT countries.name, countries.surface_area, countries.population
FROM countries
WHERE countries.surface_area > 501 AND countries.population >100000
ORDER BY countries.surface_area DESC;

SELECT countries.name, countries.government_form, countries.capital, countries.life_expectancy
FROM countries
WHERE countries.government_form = 'constitutional monarchy' AND countries.life_expectancy > 75
ORDER BY countries.capital DESC;

SELECT countries.name, cities.name, cities.district, cities.population
FROM countries
JOIN cities ON countries.id = cities.country_id
WHERE cities.district = 'Buenos Aires' AND cities.population >500000
ORDER BY cities.population DESC;

SELECT countries.region, COUNT(countries.name) AS num_countries
FROM countries
GROUP BY countries.region
ORDER BY num_countries DESC;