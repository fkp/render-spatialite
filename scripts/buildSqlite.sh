srid=$1
code=EPSG:$srid
echo building to $code
ogr2ogr -f SQLite data_$srid.sqlite -t_srs $code PG:"dbname=gis"
