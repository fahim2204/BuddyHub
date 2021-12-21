import React, { useEffect, useState } from "react";
import axios from "axios";
import { apiUrl } from "../../Config";
import { Link, useNavigate } from "react-router-dom";
import { isLoggedIn } from "../../Config";

const View = () => {
    const navigate = useNavigate();
    const [posts, setPosts] = useState([]);

    useEffect(()=>{
        axios.get(`${apiUrl}/post/5`)
        .then(resp=>{
            console.log(resp.data);
            setPosts(resp.data);
        }).catch(err=>{
            console.log(err);
        });
    },[]);
    
        
    /*useEffect(() => {
        document.title = "View";
        //GetPostData();
    }, []);*/
    /*var [postInfo, SetPostInfo] = useState({
        PostId: "",
        PostsText: "",
        CreatedAt: "",
        Status: "",
        UserId: ""
    });*/

    return (
        <>
            <div>
            
                <div className="row border rounded-3 mb-2 p-1 shadow-sm">
                    
                    <div className="row d-flex align-items-center mb-1">

                        <div className="col-6 justify-content-start d-flex">
                            <div className="me-1">
                                <img className="rounded-circle" src="" style={{ height: '30px', width: '30px' }} />
                            </div>
                            <Link to= "${apiUrl}/user/7" className="fs-6 text-success me-1 text-decoration-none">{posts.Name}</Link>
                            <div className="font-weight-light text-danger">
                                <time className="timeago" dateTime="@Model.CreatedAt" />
                            </div>
                        </div>
                        <div className="col-6 justify-content-end d-flex align-items-center">
                            <Link to={"/Post/EditPost/"+posts.Id} className="text-decoration-none">
                                <i className="fa fa-edit me-2 text-success"><span className="ms-1">Edit</span></i>
                            </Link>
                            <Link to={"/Post/RemovePost/"+posts.Id} className="text-decoration-none">
                                <i className="fa fa-trash me-2 text-danger"><span className="ms-1">Delete</span></i>
                            </Link>
                            <i className="fa fa-ellipsis-h me-1" />
                        </div>
                    </div>
                    <div className="ms-3 col-12">
                        <div className="lh-sm text-dark text-wrap">
                                {posts.PostsText}
                        </div>
                    </div>
                    <div className="row border-top mt-2 py-1 d-flex align-items-center">
                        <div className="col-6 justify-content-start d-flex">
                            <Link to={"/Post/LikeOnPost/fahim/"+posts.Id} className="btn btn-outline-primary px-2 py-0">{posts.LikeCount}<i className="fa fa-thumbs-o-up px-1 m-0" /></Link>
                            <button className="btn btn-outline-primary px-2 py-0 ms-2">{posts.CommentCount}<i className="fa fa-comment px-1 m-0" /></button>
                        </div>
                        <div className="col-6 justify-content-end d-flex">
                            <div className="mx-2"><i className="fa fa-heart me-1" /></div>
                            <div className="mx-2"><i className="fa fa-share me-1" /></div>
                        </div>
                    </div>
                </div>
                <div className="row border rounded-3 mb-2 p-1 shadow-sm">
                    <div className="row w-100">
                        <div className="col-1">
                            <img className="img-fluid img-responsive rounded-circle mr-2 m-2" src="" width={45} height={45} />
                        </div>
                        <div className="col-5">
                            <form action="" method="POST">
                                <div className="d-flex">
                                    <div className="row w-100">
                                        <div className="col-9">
                                            <input type="text" name="ctext" className="form-control mr-3 my-2" placeholder="Add comment" />
                                        </div>
                                        <div className="col-3">
                                            <button className="btn btn-primary my-2" type="submit">
                                                Comment
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <hr className="text-muted my-2" />
                    </div>
                    <h5>Comments:</h5>
                    <hr className="text-muted my-2" />

                    <h6 className="ms-4">No Comments For This Post.</h6>

                    <div className="row d-flex align-items-center mb-1">
                        <div className="col-6 justify-content-start d-flex">
                            <div className="me-1">
                                <img className="rounded-circle" src="" style={{ height: '30px', width: '30px' }} />
                            </div>
                            <Link to className="fs-6 text-success me-1 text-decoration-none"></Link>
                            <div className="font-weight-light text-danger">
                                <time className="timeago" dateTime="@item.CreatedAt" />
                            </div>
                        </div>
                        <div className="col-6 justify-content-end d-flex align-items-center">
                            <Link to={"/Post/EditPost/"+posts.Id} className="text-decoration-none">
                                <i className="fa fa-edit me-2 text-success"><span className="ms-1">Edit</span></i>
                            </Link>
                            <Link to={"/Post/RemoveComment/"+posts.Id} className="text-decoration-none">
                                <i className="fa fa-trash me-2 text-danger"><span className="ms-1">Delete</span></i>
                            </Link>
                            <i className="fa fa-ellipsis-h me-1" />
                        </div>
                    </div>
                    <div className="ms-4 col-12 mb-2">
                        <div className="lh-sm ms-2 text-dark text-wrap">
                            
                        </div>
                    </div>
                </div>
            </div>
        </>

    )

}
export default View;