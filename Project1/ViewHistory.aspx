﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ViewHistory.aspx.vb" Inherits="Project1.ViewHistory" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyBody" runat="server">

<%--<form id="form1" runat="server">
<div id="chartArea" runat="server">
    <asp:Chart ID="jobRatings" runat="server" Height="331px" Width="451px">
        <Series>
            <asp:Series Name="job1" ChartType="Line"></asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="job2">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="job3">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="Lime" Name="job4">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Color="192, 0, 192" 
                Name="job5">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</div>--%>


<%--</form>--%>
<div id="myTabContent" class="tab-content">
						<div role="tabpanel" class="tab-pane fade in active" id="home" aria-labelledby="home-tab" runat="server">
						   <div runat="server">
												<div id="container" runat = "server">
								
							
								
								
							<%--	<a href="WorkerProfile.aspx">
									<li>
									<img src="images/p1.png" title="" alt="" />
									<section class="list-left">
									<h5 class="title">Electrician</h5>
									<span class="adprice"><p> <i class="glyphicon glyphicon-map-marker"></i><a href="#">Gauteng</a>, <a href="#">Edenvale</a></p></span>
									<p class="catpath">Visit Profile</p>
									</section>
									<section class="list-right">
									</section>
									<div class="clearfix"></div>
									</li> 
								</a>--%>
							<%--	<a href="WorkerProfile.aspx">
									<li>
									<img src="images/p2.png" title="" alt="" />
									<section class="list-left">
									<h5 class="title">Electrician</h5>
									<span class="adprice"><p> <i class="glyphicon glyphicon-map-marker"></i><a href="#">Gauteng</a>, <a href="#">Dunvegan</a></p></span>
									<p class="catpath">Visit Profile</p>
									</section>
									<section class="list-right">
									</section>
									<div class="clearfix"></div>
									</li> 
								</a>
								<a href="WorkerProfile.aspx">
									<li>
									<img src="images/p3.png" title="" alt="" />
									<section class="list-left">
									<h5 class="title">Electrician</h5>
									<span class="adprice"><p> <i class="glyphicon glyphicon-map-marker"></i><a href="#">Gauteng</a>, <a href="#">Eastleigh</a></p></span>
									<p class="catpath">Visit Profile</p>
									</section>
									<section class="list-right">
									</section>
									<div class="clearfix"></div>
									</li> 
								</a>
								<a href="WorkerProfile.aspx">
									<li>
									<img src="images/p4.png" title="" alt="" />
									<section class="list-left">
									<h5 class="title">Electrician</h5>
									<span class="adprice"><p> <i class="glyphicon glyphicon-map-marker"></i><a href="#">Gauteng</a>, <a href="#">Randburg</a></p></span>
									<p class="catpath">Visit Profile</p>
									</section>
									<section class="list-right">
									</section>
									<div class="clearfix"></div>
									</li> 
								</a>
								<a href="WorkerProfile.aspx">
									<li>
									<img src="images/p1.png" title="" alt="" />
									<section class="list-left">
									<h5 class="title">Electrician</h5>
									<span class="adprice"><p> <i class="glyphicon glyphicon-map-marker"></i><a href="#">Gauteng</a>, <a href="#">Dowerglen</a></p></span>
									<p class="catpath">Visit Profile</p>
									</section>
									<section class="list-right">
									</section>
									<div class="clearfix"></div>
									</li> 
								</a>--%>
							
						</div>
							</div>
						</div>
						
						
						
					  </div>

</asp:Content>
