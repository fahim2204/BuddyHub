import React, { useEffect, useState } from "react";
import axios from "axios";
import { apiUrl } from "../../Config";
import { Link, useNavigate } from "react-router-dom";
import { isLoggedIn } from "../../Config";

const Allpost = () => {
    const navigate = useNavigate();
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        axios.get(`${apiUrl}/post`)
            .then(resp => {
                console.log(resp.data);
                setPosts(resp.data);
            }).catch(err => {
                console.log(err);
            });
    }, []);
    return (
        <>


            {
               posts.map((post) =>{
                <div className="row border rounded-3 mb-2 p-1 shadow-sm">
            
                <div className="row d-flex align-items-center mb-1">
                  <div className="col-6 justify-content-start d-flex">
                    <div className="me-1">
                      <img className="rounded-circle" src="" style={{height: '30px', width: '30px'}} />
                    </div>
                    <a href="/Profile/@Html.DisplayFor(modelItem => item.Username)" className="fs-6 text-success me-1 text-decoration-none">@Html.DisplayFor(modelItem =&gt; item.Username)</a>
                    <div className="font-weight-light text-danger">
                      <time className="timeago" dateTime="@Html.DisplayFor(modelItem => item.CreatedAt)" />
                    </div>
                  </div>
                  <div className="col-6 justify-content-end d-flex">
                 
                    <a href="\Post\EditPost\@Html.DisplayFor(modelItem => item.PostId)" className="text-decoration-none">
                      <i className="fa fa-edit me-2 text-success"><span className="ms-1">Edit</span></i>
                    </a>
                    <a href="\Post\RemovePost\@Html.DisplayFor(modelItem => item.PostId)" className="text-decoration-none">
                      <i className="fa fa-trash me-2 text-danger"><span className="ms-1">Delete</span></i>
                    </a>
                    {'}'}
                    <i className="fa fa-ellipsis-h me-1" />
                  </div>
                </div>
              
                <div className="ms-3 col-12">
                  <a className="text-decoration-none text-black" href="@Url.Action(" view", "post", new {id="@Html.DisplayFor(modelItem" => item.PostId){'}'})"&gt;
                    <div className="lh-sm text-dark text-wrap">
                   
                    </div>
                  </a>
                </div>
                <div className="row border-top mt-2 py-1 d-flex align-items-center">
                  <div className="col-6 justify-content-start d-flex">
                    <a href="" class="btn btn-outline-primary px-2 py-0"<i className="fa fa-thumbs-o-up px-1 m-0" /></a>
                    <a href="@Url.Action(" view", "post", new {id="@Html.DisplayFor(modelItem" => item.PostId){'}'})" class="btn btn-outline-primary px-2 py-0 ms-2"&gt;@Html.DisplayFor(modelItem =&gt; item.Comments.Count) Comments<i className="fa fa-comment px-1 m-0" /></a>
                  </div>
                  <div className="col-6 justify-content-end d-flex">
                    <a href="/Save/CheckPost/@item.PostId"><div className="mx-2"><i className="fa fa-heart me-1" /></div></a>
                    <div className="mx-2"><i className="fa fa-share me-1" /></div>
                  </div>
                </div>
              </div>
              
               })
            }
           
       </>
   )
}
export default Allpost;