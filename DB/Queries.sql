--Lista de precios de los productos
SELECT 
	NAME,
	PRICE
FROM 
	PRODUCT
	
--Productos con minimo permitido
SELECT
	* 
FROM 
	PRODUCT P
WHERE 
	P.UNITS <= 5
	
--clientes menores de 35 con compras entre el 1 de febrero y mayo 25 del 2000
SELECT
	C.IDENTIFICAION,
	C.FULLNAME
FROM
	CUSTOMER C

INNER JOIN BILL B
	ON B.CUSTOMER_ID = C.ID
WHERE 
	date_part('year',age(C.BIRTH,CURRENT_DATE)) < 35
AND 
	B.SOLD BETWEEN '2000-02-01' AND '2000-05-25'

-- Productos vendidos en el año 2000
SELECT 
	P.NAME,
	SUM(BD.PRICE)
FROM PRODUCT P
INNER JOIN BILL_DETAIL BD 
	ON BD.PRODUCT_ID = P.ID
INNER JOIN BILL B
	ON B.ID = BD.BILL_ID
WHERE date_part('year',B.SOLD) = 2000
GROUP BY P.NAME

--Estimar frecuencia de compras (sin terminar)

SELECT
	C.FULLNAME,
	B.SOLD
FROM CUSTOMER C
INNER JOIN BILL B
	ON B.CUSTOMER_ID = C.ID


