﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site2.Master" CodeBehind="ClientProfile.aspx.vb" Inherits="Project1.ClientProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="single-page main-grid-border">
		<div class="container">
			<ol class="breadcrumb" style="margin-bottom: 5px;">
				<li><a href="index.html" style="font-size:18px">Home</a></li>
				<li class="active" style="font-size:18px">Client's Profile</li>
			</ol>
			<div class="product-desc">
				<div class="col-md-7 product-view">
                    <h1>My Profile</h1>  
					<p > <i class="glyphicon glyphicon-map-marker"></i><a href="#" style="font-size:16px">Gauteng</a>, <a href="#" style="font-size:16px"><label id="lblRegion" runat="server" text=""/></a></p>
					
					<!-- FlexSlider -->
					  <script src="js/jquery.flexslider.js"></script>
					<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />

						<script>
					// Can also be used with $(document).ready()
					$(window).load(function() {
					  $('.flexslider').flexslider({
						animation: "slide",
						controlNav: "thumbnails"
					  });
					});
					</script>
					<!-- //FlexSlider -->
					<div class="product-details" runat="server" >
						<h4>Name : <a href="#"><label id="lblName" runat="server" text=""></label> <label id="lblSurname" runat="server" text=""></label></a></h4>
                        <h4>Contact Number : <a href="#"><label id="lblNumber" runat="server" text=""></label></a></h4>
						<h4>Email : <a href="#"><label id="lblEmail" runat="server" text=""></label></a></h4>
						<h4>Address : <a href="#"><label id="lblAddress" runat="server" text=""></label></a></h4>
                       
                        <p id="update" runat="server"><a href="UpdateProfile.aspx?user=client">Update Your Profile</a></p>
                        <p id="check" runat="server"><a href="clientStat.aspx?user=client">Check Your Stats</a></p>

					</div>
                        
                       
				</div>
				<div class="col-md-5 product-details-grid">
					<%--<div class="item-price">

						<div class="condition">
							<p class="p-price">Rating</p>
							<h4><i><img src="images/rate1.png" alt=" " /></i></h4>
							<div class="clearfix"></div>
						</div>
					</div>--%>
					<div class="interested text-center">
						<h4 style="text-align:center;">Interested?</h4>
						<p><a href="PostAdClient.aspx" style="color:white">Post an ad</a></p>
                        <p><a href="FeaturedWorkers.aspx" style="color:white">Check out Featured Workers</a></p>
                        <br/>
                        
                      

					</div>
                    <p style="align-content:center">&nbsp;</p>
                   <!-- <br /> <hr />-->
                       <div class="interested text-center"  id="AdsDiv" runat="server">
                
			           </div>

                    <div class="interested text-center"  id="quotationDiv" runat="server">
                
			           </div>
				</div>
			
			</div>
		</div>
	</div>

   

    </label>

   

</asp:Content>
