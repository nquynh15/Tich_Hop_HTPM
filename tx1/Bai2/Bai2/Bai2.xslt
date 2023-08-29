<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DS">
		<html>
			<head>
				<link rel="stylesheet" type="text/css" href="Bai2.css"/>
			</head>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG</h1>
				<h1 align="center">-------------------------------------------</h1>							
				<xsl:apply-templates select="congty"/>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="congty">
		<h3>
			<b>Tên công ty: <xsl:value-of select="@TenCT"/></b>
		</h3>
		<xsl:apply-templates select="donvi"/>
		<br/>
		<hr/>
		<br/>
	</xsl:template>
	<xsl:template match="donvi">
		<h3>
			<b>
				Tên phòng: <xsl:value-of select="tendv"/>
			</b>
		</h3>
		<table class="bang" border="1" cellspacing="0">
			<tr>
				<th>STT</th>
				<th>Họ tên</th>
				<th>Ngày sinh</th>
				<th>Ngày công</th>
				<th>Lương</th>
			</tr>
			<xsl:apply-templates select="nhanvien"/>
		</table>
	</xsl:template>
	<xsl:template match="nhanvien">
		<tr>
			<td>
				<xsl:value-of select="position()"/>
			</td>
			<td>
				<xsl:value-of select="hoten"/>
			</td>
			<td>
				<xsl:value-of select="ngaysinh"/>
			</td>
			<td>
				<xsl:value-of select="ngaycong"/>
			</td>
			<td>
				<xsl:choose>
					<xsl:when test="ngaycong &gt;= 20">
						<xsl:value-of select="ngaycong*150000"/>
					</xsl:when>
					<xsl:when test="ngaycong &gt;= 25">
						<xsl:value-of select="20 * 150000 + (ngaycong-20) * 200000"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="20 * 150000 + 5 * 200000 + (ngaycong-25) * 250000"/>						
					</xsl:otherwise>
				</xsl:choose>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
