SELECT SCHEMA_NAME
FROM INFORMATION_SCHEMA.SCHEMATA

-- 6 TASK datatype
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo'

-- 7 TASK SRID

--SRID - это уникальный идентификатор, который определяет пространственную систему координат
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ne_50m_playas' AND DATA_TYPE = 'geometry'

select distinct geom.STSrid as SRID from [ne_50m_playas] 


-- 8 TASK аттрибутивные столбцы
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo' AND DATA_TYPE <> 'geometry'

-- 9 TASK WRT
SELECT geom.STAsText() AS WKT_Description
FROM [ne_50m_playas]

-- 10 TASKS
select * from [ne_50m_playas]

-- 10.1 Intersaction


DECLARE @lineGeometry GEOMETRY;
SET @lineGeometry = GEOMETRY::STGeomFromText('LINESTRING(30 10, 10 30, 40 40)', 0);


DECLARE @lineGeometry2 GEOMETRY;
SET @lineGeometry2 = GEOMETRY::STGeomFromText('LINESTRING(30 10, 10 30, 40 40)', 0);


SELECT @lineGeometry.STIntersection(@lineGeometry2) AS Intersection
FROM [ne_50m_playas]

--SELECT obj1.geom.STIntersection(obj2.geom) AS Intersection
--FROM [ne_50m_playas] obj1, [ne_50m_playas] obj2
--WHERE obj1.qgs_fid = 1 AND obj2.qgs_fid = 2



-- 10.2 Union

SELECT obj1.geom.STUnion(obj2.geom) AS [Union]
FROM [ne_50m_playas] obj1, [ne_50m_playas] obj2
WHERE obj1.qgs_fid = 3 AND obj2.qgs_fid = 2

-- 10.3 WithIn - отсутствует

SELECT obj1.geom.STWithin(obj2.geom) AS [IsWithin]
FROM [ne_50m_playas] obj1, [ne_50m_playas] obj2
WHERE obj1.qgs_fid = 1 AND obj2.qgs_fid = 2

-- 10.4 Simplified (не поддерживается, использовал Reduce)

SELECT geom.Reduce(0.1) AS Simplified --насколько сильно должен быть упрощен геометрический объект
FROM [ne_50m_playas]
WHERE qgs_fid = 6

-- 10.5 VertexCoordinates

SELECT geom.STPointN(1).ToString() AS VertexCoordinates
FROM [ne_50m_playas]
WHERE qgs_fid = 6

-- 10.6 ObjectDimension (отсутствуют)

SELECT geom.STDimension() AS ObjectDimension
FROM [ne_50m_playas]
WHERE qgs_fid = 3

-- 10.7 ObjectLength, ObjectArea (отсутствуют)

SELECT geom.STLength() AS ObjectLength, geom.STArea() AS ObjectArea
FROM [ne_50m_playas]
WHERE qgs_fid = 5


-- 10.8 Distance

SELECT obj1.geom.STDistance(obj2.geom) AS Distance
FROM [ne_50m_playas] obj1, [ne_50m_playas] obj2
WHERE obj1.qgs_fid = 6 AND obj2.qgs_fid = 4


-- 11 point, line, polygon

DECLARE @pointGeometry GEOMETRY;
SET @pointGeometry = GEOMETRY::STGeomFromText('POINT(30 10)', 0);

SELECT @pointGeometry AS PointGeometry;


DECLARE @lineGeometry3 GEOMETRY;
SET @lineGeometry3 = GEOMETRY::STGeomFromText('LINESTRING(30 10, 10 30, 40 40)', 0);

SELECT @lineGeometry3 AS LineGeometry3;



DECLARE @polygonGeometry GEOMETRY;
SET @polygonGeometry = GEOMETRY::STGeomFromText('POLYGON((35 10, 45 45, 15 40, 10 20, 35 10))', 0);

SELECT @polygonGeometry AS PolygonGeometry;


-- 12 

-- точка и полигон
DECLARE @point GEOMETRY = GEOMETRY::STGeomFromText('POINT(30 30)', 0);
DECLARE @polygon GEOMETRY = GEOMETRY::STGeomFromText('POLYGON((20 20, 20 40, 40 40, 40 20, 20 20))', 0);

SELECT @point.STWithin(@polygon) AS PointWithinPolygon;

-- прямая и полигон
DECLARE @line GEOMETRY = GEOMETRY::STGeomFromText('LINESTRING(30 10, 10 30, 40 40)', 0);
DECLARE @polygonn GEOMETRY = GEOMETRY::STGeomFromText('POLYGON((20 20, 20 40, 40 40, 40 20, 20 20))', 0);

SELECT @line.STIntersects(@polygonn) AS LineIntersectsPolygon;